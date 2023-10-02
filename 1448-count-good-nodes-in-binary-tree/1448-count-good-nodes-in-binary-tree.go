func goodNodes(root *TreeNode) int {
	return countGoodNodes(root, root.Val)
}

func countGoodNodes(root *TreeNode, max int) int {
	if root == nil {
		return 0
	}

	if root.Val >= max {
		return 1 + countGoodNodes(root.Left, root.Val) + countGoodNodes(root.Right, root.Val)
	} else {
		return countGoodNodes(root.Left, max) + countGoodNodes(root.Right, max)
	}
}
