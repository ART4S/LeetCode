func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {
	head, prev, cur, remainder := l1, l1, l1, 0

	for l1 != nil || l2 != nil {
		var a, b int

		if l1 != nil {
			a = l1.Val
			l1 = l1.Next
		}

		if cur == nil {
			cur = l2
			prev.Next = cur
		}

		if l2 != nil {
			b = l2.Val
			l2 = l2.Next
		}

		sum := a + b + remainder
		cur.Val = sum % 10
		remainder = sum / 10
		prev, cur = cur, cur.Next
	}

	if remainder > 0 {
		prev.Next = &ListNode{Val: remainder}
	}

	return head
}