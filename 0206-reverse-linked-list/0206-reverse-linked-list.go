
func reverseList(head *ListNode) *ListNode {
	var prev, cur *ListNode = nil, head

	for cur != nil {
		cur.Next, cur, prev = prev, cur.Next, cur
	}

	return prev
}