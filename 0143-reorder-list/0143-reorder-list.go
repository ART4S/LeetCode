func reorderList(head *ListNode) {
	list := make([]*ListNode, 0)

	for cur := head; cur != nil; cur = cur.Next {
		list = append(list, cur)
	}

	l, r := 0, len(list)-1

	for l < r {
		list[l].Next, list[r].Next = list[r], list[l].Next
		l, r = l+1, r-1
	}

	list[l].Next = nil
}