func hasCycle(head *ListNode) bool {
	flag := &ListNode{}
	
	for head != nil && head != flag {
		head, head.Next = head.Next, flag
	}

	return head == flag
}