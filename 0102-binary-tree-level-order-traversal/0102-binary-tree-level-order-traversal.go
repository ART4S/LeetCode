func levelOrder(root *TreeNode) [][]int {
	result := make([][]int, 0)

	if root == nil {
		return result
	}

	que := NewQueue[*TreeNode]()

	que.Push(root)

	for que.Len() > 0 {
		level := make([]int, que.Len())

		result = append(result, level)

		for i := range level {
			node := que.Pop()

			level[i] = node.Val

			if node.Left != nil {
				que.Push(node.Left)
			}

			if node.Right != nil {
				que.Push(node.Right)
			}
		}
	}

	return result
}

type Queue[T any] interface {
	Push(item T)
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

func (this *queue[T]) Pop() T {
	result := this.items[0]
	this.items = this.items[1:]
	return result
}

func (this *queue[T]) Len() int {
	return len(this.items)
}
