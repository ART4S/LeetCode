func lowestCommonAncestor(root, p, q *TreeNode) *TreeNode {

	var result *TreeNode

	FindAnyNode(root, p, q, &result)

	return result
}

func FindAnyNode(root, p, q *TreeNode, result **TreeNode) bool {
	if root == nil {
		return false
	}

	found := 0

	if root == p || root == q {
		found++
	}

	if found < 2 && FindAnyNode(root.Left, p, q, result) {
		found++
	}

	if found < 2 && FindAnyNode(root.Right, p, q, result) {
		found++
	}

	if found == 2 && *result == nil {
		*result = root
	}

	return found > 0
}