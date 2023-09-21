func maxDepth(root *TreeNode) int {
	return findMaxDepth(root, 0)
}

func findMaxDepth(root *TreeNode, depth int) int {
	if root == nil {
		return depth
	}

	depth += 1

	return max(findMaxDepth(root.Left, depth), findMaxDepth(root.Right, depth))
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}