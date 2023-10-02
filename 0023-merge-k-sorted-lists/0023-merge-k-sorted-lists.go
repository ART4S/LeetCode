func mergeKLists(lists []*ListNode) *ListNode {

	type pair struct {
		node  *ListNode
		index int
	}

	head := &ListNode{}
	tail := head

	for {
		toAdd := make([]*pair, 0)

		min := math.MaxInt

		for i, n := range lists {
			if n == nil {
				continue
			}

			if n.Val < min {
				toAdd = append(toAdd[0:0], &pair{n, i})
				min = n.Val
			} else if n.Val == min {
				toAdd = append(toAdd, &pair{n, i})
			}
		}

		if len(toAdd) == 0 {
			break
		}

		for _, p := range toAdd {
			lists[p.index] = p.node.Next
			tail.Next = &ListNode{Val: p.node.Val}
			tail = tail.Next
		}
	}

	return head.Next
}