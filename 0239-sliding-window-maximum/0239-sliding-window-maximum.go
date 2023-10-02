func maxSlidingWindow(nums []int, k int) []int {
	res := make([]int, 0)
	ignore := make(map[int]int)
	pq := NewPriorityQueue[int]()

	for i := 0; i < len(nums); i++ {
		if i >= k {
			ignore[nums[i-k]]++

			for !pq.Empty() && ignore[pq.Peek()] > 0 {
				ignore[pq.Pop()]--
			}
		}

		pq.Push(nums[i], -nums[i])

		if i >= k-1 {
			res = append(res, pq.Peek())
		}
	}

	return res
}

type PriorityQueue[TKey any] interface {
	Push(key TKey, priority int)
	Peek() TKey
	Pop() TKey
	Empty() bool
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
		heapify_down(this, 0)
	}

	return result.key
}

func (this *heap[TKey]) Empty() bool {
	return len(this.items) == 0
}

func heapify_up[TKey any](this *heap[TKey], i int) {
	for i != 0 {
		parent := (i - 1) / 2
		if less(this, i, parent) {
			swap(this, i, parent)
			i = parent
		} else {
			break
		}
	}
}

func heapify_down[TKey any](this *heap[TKey], i int) {
	left := 2*i + 1
	right := 2*i + 2
	smallest := i

	if left < len(this.items) && less(this, left, smallest) {
		smallest = left
	}

	if right < len(this.items) && less(this, right, smallest) {
		smallest = right
	}

	if smallest != i {
		swap(this, i, smallest)
		heapify_down(this, smallest)
	}
}

func less[TKey any](this *heap[TKey], i int, j int) bool {
	return this.items[i].priority < this.items[j].priority
}

func swap[TKey any](this *heap[TKey], i, j int) {
	this.items[i], this.items[j] = this.items[j], this.items[i]
}
