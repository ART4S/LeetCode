type Twitter struct {
	users map[int]*User
	time  int
}

type User struct {
	userId     int
	followers  map[int]*User
	followings map[int]*User
	posts      *Posts
	feed       PriorityQueue[*Tweet]
}

type Posts struct {
	headSentinel *Tweet
	tailSentinel *Tweet
	count        int
}

type Tweet struct {
	tweetId   int
	userId    int
	timestamp int
	prev      *Tweet
	next      *Tweet
}

func Constructor() Twitter {
	return Twitter{
		users: make(map[int]*User, 0),
		time:  0,
	}
}

func newUser(userId int) *User {
	return &User{
		userId:     userId,
		followers:  make(map[int]*User),
		followings: make(map[int]*User),
		posts:      newPosts(),
		feed:       newFeed(),
	}
}

func newPosts() *Posts {
	hs := &Tweet{}
	ts := &Tweet{}

	hs.next = ts
	ts.prev = hs

	return &Posts{hs, ts, 0}
}

func newFeed() PriorityQueue[*Tweet] {
	return NewPriorityQueue[*Tweet]()
}

func newTweet(tweetId, userId, timestamp int) *Tweet {
	return &Tweet{
		tweetId:   tweetId,
		userId:    userId,
		timestamp: timestamp,
		prev:      nil,
		next:      nil,
	}
}

func (this *Twitter) PostTweet(userId int, tweetId int) {
	user, ok := this.users[userId]
	if !ok {
		user = newUser(userId)
		this.users[userId] = user
	}

	this.time++

	tweet := newTweet(tweetId, userId, this.time)

	user.posts.addTweet(tweet)

	user.feed.Push(tweet, -tweet.timestamp)

	for _, f := range user.followers {
		f.feed.Push(tweet, -tweet.timestamp)
	}
}

func (this *Posts) addTweet(tweet *Tweet) {
	if this.count == 10 {
		removeTweet := this.headSentinel.next
		link(this.headSentinel, removeTweet.next)
		removeTweet.next, removeTweet.prev = nil, nil
	} else {
		this.count++
	}
	link(this.tailSentinel.prev, tweet)
	link(tweet, this.tailSentinel)
}

func link(t1, t2 *Tweet) {
	t1.next = t2
	t2.prev = t1
}

func (this *Twitter) GetNewsFeed(userId int) (feed []int) {
	user, ok := this.users[userId]
	if !ok {
		return
	}

	n := 10

	actualTweets := make([]*Tweet, 0, n)

	for n > 0 && user.feed.Len() > 0 {
		t, _ := user.feed.Pop()
		if t.userId != user.userId {
			if _, ok := user.followings[t.userId]; !ok {
				continue
			}
		}
		actualTweets = append(actualTweets, t)
		feed = append(feed, t.tweetId)
		n--
	}

	for _, t := range actualTweets {
		user.feed.Push(t, -t.timestamp)
	}

	return
}

func (this *Twitter) Follow(followerId int, followeeId int) {
	follower, ok := this.users[followerId]
	if !ok {
		follower = newUser(followerId)
		this.users[followerId] = follower
	}

	followee, ok := this.users[followeeId]
	if !ok {
		followee = newUser(followeeId)
		this.users[followeeId] = followee
	}

	if _, ok := followee.followers[followerId]; ok {
		return
	}

	followee.followers[followerId] = follower
	follower.followings[followeeId] = followee

	cur := followee.posts.tailSentinel.prev

	for cur != followee.posts.headSentinel {
		follower.feed.Push(cur, -cur.timestamp)
		cur = cur.prev
	}
}

func (this *Twitter) Unfollow(followerId int, followeeId int) {
	follower := this.users[followerId]
	followee := this.users[followeeId]

	delete(followee.followers, followerId)
	delete(follower.followings, followeeId)
}

// ----------------------------------Priority queue---------------------------------------
type PriorityQueue[TKey any] interface {
	Push(key TKey, priority int)
	Peek() (TKey, int)
	Pop() (TKey, int)
	Len() int
}

type priorityQueue[TKey any] struct {
	items []*item[TKey]
}

type item[TKey any] struct {
	key      TKey
	priority int
}

func NewPriorityQueue[TKey any]() PriorityQueue[TKey] {
	return &priorityQueue[TKey]{items: make([]*item[TKey], 0)}
}

func (this *priorityQueue[TKey]) Push(key TKey, priority int) {
	this.items = append(this.items, &item[TKey]{key, priority})

	heapify_up(this, len(this.items)-1)
}

func (this *priorityQueue[TKey]) Peek() (TKey, int) {
	return this.items[0].key, this.items[0].priority
}

func (this *priorityQueue[TKey]) Pop() (TKey, int) {
	result := this.items[0]
	this.items[0] = this.items[len(this.items)-1]
	this.items = this.items[:len(this.items)-1]

	if len(this.items) > 1 {
		this.heapify_down(0)
	}

	return result.key, result.priority
}

func (this *priorityQueue[TKey]) Len() int {
	return len(this.items)
}

func heapify_up[TKey any](this *priorityQueue[TKey], i int) {
	for i != 0 {
		parent := (i - 1) / 2
		if this.less(i, parent) {
			this.swap(i, parent)
			i = parent
		} else {
			break
		}
	}
}

func (this *priorityQueue[TKey]) heapify_down(i int) {
	left := 2*i + 1
	right := 2*i + 2
	smallest := i

	if left < len(this.items) && this.less(left, smallest) {
		smallest = left
	}

	if right < len(this.items) && this.less(right, smallest) {
		smallest = right
	}

	if smallest != i {
		this.swap(i, smallest)
		this.heapify_down(smallest)
	}
}

func (this *priorityQueue[TKey]) less(i int, j int) bool {
	return this.items[i].priority < this.items[j].priority
}

func (this *priorityQueue[TKey]) swap(i, j int) {
	this.items[i], this.items[j] = this.items[j], this.items[i]
}

// ----------------------------------Disjoint set---------------------------------------
type DisjointSet interface {
	GetParent(x int) int
	Unite(x int, y int)
}

type disjointSet struct {
	parent []int
	rank   []int
}

func NewDisjointSet(size int) DisjointSet {
	var ds = &disjointSet{make([]int, size+1), make([]int, size+1)}

	for i := 1; i <= size; i++ {
		ds.parent[i] = i
	}

	return ds
}

func (this *disjointSet) GetParent(x int) int {
	if this.parent[x] == x {
		return x
	}

	newParent := this.GetParent(this.parent[x])

	this.parent[x] = newParent

	return newParent
}

func (this *disjointSet) Unite(x int, y int) {
	parentX := this.GetParent(x)
	parentY := this.GetParent(y)

	if parentX == parentY {
		return
	}

	if this.rank[parentX] < this.rank[parentY] {
		parentX, parentY = parentY, parentX
	}

	this.parent[parentY] = parentX

	if this.rank[parentX] == this.rank[parentY] {
		this.rank[parentX]++
	}
}

// ----------------------------------Queue---------------------------------------
type Queue[T any] interface {
	Push(item T)
	Peek() T
	Pop() T
	Len() int
}

type queue[T any] struct {
	items []T
}

func NewQueue[T any]() Queue[T] {
	return &queue[T]{make([]T, 0)}
}

func (this *queue[T]) Push(item T) {
	this.items = append(this.items, item)
}

func (this *queue[T]) Peek() T {
	return this.items[0]
}

func (this *queue[T]) Pop() T {
	result := this.items[0]
	this.items = this.items[1:]
	return result
}

func (this *queue[T]) Len() int {
	return len(this.items)
}

// ----------------------------------Stack---------------------------------------
type Stack[T any] interface {
	Push(item T)
	Peek() T
	Pop() T
	Len() int
}

type stack[T any] struct {
	items []T
}

func NewStack[T any]() Stack[T] {
	return &stack[T]{make([]T, 0)}
}

func (this *stack[T]) Push(item T) {
	this.items = append(this.items, item)
}

func (this *stack[T]) Peek() T {
	return this.items[len(this.items)-1]
}

func (this *stack[T]) Pop() T {
	result := this.items[len(this.items)-1]
	this.items = this.items[:len(this.items)-1]
	return result
}

func (this *stack[T]) Len() int {
	return len(this.items)
}

// ----------------------------------Set---------------------------------------
type Set[T comparable] interface {
	Add(item T) bool
	Remove(item T) bool
	Enumerate(func(item T))
	Len() int
}

type set[T comparable] struct {
	items map[T]bool
}

func NewSet[T comparable]() Set[T] {
	return &set[T]{make(map[T]bool)}
}

func (this *set[T]) Add(item T) bool {
	_, ok := this.items[item]

	if ok {
		return false
	}

	this.items[item] = true

	return true
}

func (this *set[T]) Remove(item T) bool {
	_, ok := this.items[item]

	if ok {
		delete(this.items, item)
		return true
	}

	return false
}

func (this *set[T]) Enumerate(action func(item T)) {
	for k := range this.items {
		action(k)
	}
}

func (this *set[T]) Len() int {
	return len(this.items)
}

// ----------------------------------Math---------------------------------------
func Max[T orderable](a, b T) T {
	if a > b {
		return a
	}
	return b
}

func Min[T orderable](a, b T) T {
	if a < b {
		return a
	}
	return b
}

func MaxInt(a, b int) int {
	if a > b {
		return a
	}
	return b
}

func MinInt(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func Abs[T orderable](a T) T {
	if a > 0 {
		return a
	}
	return -a
}

// ----------------------------------Quick Select Algorithm---------------------------------------
func QuickSelect[T orderable](arr []T, ind int) (res T) {
	// https://algs4.cs.princeton.edu/23quicksort/

	l, r := 0, len(arr)-1

	for {
		pivot := hoarePartition(l, r, arr)

		switch {
		case pivot == ind:
			return arr[ind]
		case pivot < ind:
			l = pivot + 1
		default:
			r = pivot - 1
		}
	}
}

// https://algs4.cs.princeton.edu/23quicksort/
func hoarePartition[T orderable](start, end int, arr []T) int {
	/*
	 * pl--------------------------r
	 * p---<=p---l--------r--->=p---
	 * ---<=p--------p-------->=p---
	 */

	m := start + (end-start)/2
	arr[m], arr[start] = arr[start], arr[m]
	pivot := arr[start]

	l, r := start, end+1

	for {
		for l < end {
			l++
			if arr[l] >= pivot {
				break
			}
		}

		for {
			r--
			if arr[r] <= pivot {
				break
			}
		}

		if l >= r {
			break
		}

		arr[l], arr[r] = arr[r], arr[l]
	}

	arr[start], arr[r] = arr[r], arr[start]

	return r
}

func entropyOptimalPartition[T orderable](start, end int, arr []T) int {
	/*
	 * p(l,i)-----------------------------r
	 * p---<p---l---=p---i---?---r--->p----
	 * ----<p-----------=p----------->p----
	 */

	m := start + (end-start)/2
	arr[m], arr[start] = arr[start], arr[m]
	pivot := arr[start]

	l, r := start+1, end
	i := l

	for i <= r {
		switch c := arr[i] - pivot; {
		case c < 0:
			arr[l], arr[i] = arr[i], arr[l]
			i++
			l++
		case c > 0:
			arr[r], arr[i] = arr[i], arr[l]
			r--
		default:
			i++
		}
	}

	arr[start], arr[r] = arr[r], arr[start]

	return r
}

// helper types
type orderable interface {
	~float32 | ~float64 |
		~int | ~int8 |
		~int16 | ~int32 |
		~int64 | ~uint |
		~uint8 | ~uint16 |
		~uint32 | ~uint64
}