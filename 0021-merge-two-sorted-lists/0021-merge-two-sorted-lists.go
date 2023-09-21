func mergeTwoLists(list1 *ListNode, list2 *ListNode) *ListNode {
	i, j := list1, list2

	head := &ListNode{}
	tail := head

	for i != nil || j != nil {

		if i != nil && j != nil {
			if i.Val < j.Val {
				tail.Next, i = i, i.Next
			} else {
				tail.Next, j = j, j.Next
			}
		} else if i != nil {
			tail.Next = i
			break
		} else {
			tail.Next = j
			break
		}

		tail = tail.Next
	}

	return head.Next
}