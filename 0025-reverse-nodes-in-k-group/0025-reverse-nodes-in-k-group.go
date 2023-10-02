func reverseKGroup(head *ListNode, k int) *ListNode {
	stack := NewStack[*ListNode]()
	headSentinel := &ListNode{}
	prev := headSentinel
	i := 0
	for cur := head; cur != nil; cur = cur.Next {
		i++
		if i%(k+1) == k {
			i = 0
			n := cur
			next := n.Next
			for !stack.Empty() {
				n.Next = stack.Pop()
				n = n.Next
			}
			n.Next = next
			prev.Next = cur
			prev, cur = n, n
		} else {
			stack.Push(cur)
		}
	}

	return headSentinel.Next
}

type Stack[T any] interface {
	Push(item T)
	Pop() T
	Empty() bool
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

func (this *stack[T]) Pop() T {
	result := this.items[len(this.items)-1]
	this.items = this.items[:len(this.items)-1]
	return result
}

func (this *stack[T]) Empty() bool {
	return len(this.items) == 0
}