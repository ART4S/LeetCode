func isValidBST(root *TreeNode) bool {
	var prev *TreeNode;
	
	return checkBST(root, &prev)
}

func checkBST(root *TreeNode, prev **TreeNode) bool {
	if root == nil {
		return true
	}

	if !checkBST(root.Left, prev) {
		return false
	}

	if *prev == nil {
		*prev = root
	} else {
		if (**prev).Val >= root.Val {
			return false
		}
		*prev = root
	}

	return checkBST(root.Right, prev)
}