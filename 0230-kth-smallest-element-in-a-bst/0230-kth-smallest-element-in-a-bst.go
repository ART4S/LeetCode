func kthSmallest(root *TreeNode, k int) int {
	return find(root, &k)
}

func find(root *TreeNode, k *int) int {
	if root == nil {
		return -1
	}

	res := find(root.Left, k)

	if res != -1 {
		return res
	}

	*k--
	if *k == 0 {
		return root.Val
	}

	return find(root.Right, k)
}