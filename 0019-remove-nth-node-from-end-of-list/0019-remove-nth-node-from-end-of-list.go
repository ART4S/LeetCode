func removeNthFromEnd(head *ListNode, n int) *ListNode {
	slow, fast := head, head
	l, r := 1, 1

	for fast.Next != nil {
		fast = fast.Next
		r++
		if fast.Next != nil {
			fast = fast.Next
			r++
		} else {
			break
		}
		slow = slow.Next
		l++
	}

	var prev, cur *ListNode

	start, end := 1, r-n+1

	if end > l {
		prev, cur, start = slow, slow, l
	} else {
		prev, cur = head, head
	}

	for i := start; i < end; i++ {
		prev, cur = cur, cur.Next
	}

	if prev == cur {
		return prev.Next
	}

	prev.Next = cur.Next

	return head
}