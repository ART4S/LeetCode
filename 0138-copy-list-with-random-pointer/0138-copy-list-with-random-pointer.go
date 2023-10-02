func copyRandomList(head *Node) *Node {
	nodes := make(map[*Node]*Node)

	for cur := head; cur != nil; cur = cur.Next {
		nodes[cur] = &Node{}
	}

	slow := &Node{}
	fast := slow

	for cur := head; cur != nil; cur = cur.Next {
		fast.Next = nodes[cur]
		fast.Next.Val = cur.Val
		fast.Next.Random = nodes[cur.Random]
		fast = fast.Next
	}

	return slow.Next
}