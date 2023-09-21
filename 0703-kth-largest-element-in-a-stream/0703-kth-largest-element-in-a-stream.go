type KthLargest struct {
	k   int
	que PriorityQueue[int]
}

func Constructor(k int, nums []int) KthLargest {
	que := NewPriorityQueue[int]()
	for _, n := range nums {
		que.Push(n, n)
	}
	return KthLargest{k, que}
}

func (this *KthLargest) Add(val int) int {
	this.que.Push(val, val)

	for this.que.Len() > this.k {
		this.que.Pop()
	}

	return this.que.Peek()
}

type PriorityQueue[TKey any] interface {
	Push(key TKey, priority int)
	Peek() TKey
	Pop() TKey
	Len() int
}

type heap[TKey any] struct {
	items []*item[TKey]
}

type item[TKey any] struct {
	key      TKey
	priority int
}

func NewPriorityQueue[TKey any]() PriorityQueue[TKey] {
	return &heap[TKey]{items: make([]*item[TKey], 0)}
}

func (this *heap[TKey]) Push(key TKey, priority int) {
	this.items = append(this.items, &item[TKey]{key, priority})

	heapify_up(this, len(this.items)-1)
}

func (this *heap[TKey]) Peek() TKey {
	return this.items[0].key
}

func (this *heap[TKey]) Pop() TKey {
	result := this.items[0]
	this.items[0] = this.items[len(this.items)-1]
	this.items = this.items[:len(this.items)-1]

	if len(this.items) > 1 {
		this.heapify_down(0)
	}

	return result.key
}

func (this *heap[TKey]) Len() int {
	return len(this.items)
}

func heapify_up[TKey any](this *heap[TKey], i int) {
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

func (this *heap[TKey]) heapify_down(i int) {
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

func (this *heap[TKey]) less(i int, j int) bool {
	return this.items[i].priority < this.items[j].priority
}

func (this *heap[TKey]) swap(i, j int) {
	this.items[i], this.items[j] = this.items[j], this.items[i]
}