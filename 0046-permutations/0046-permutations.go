func permute(nums []int) [][]int {
	res := make([][]int, 0)
	traverse(0, nums, &res)
	return res
}

func traverse(idx int, perm []int, res *[][]int) {
	if idx == len(perm) {
		*res = append(*res, append([]int(nil), perm...))
		return
	}

	for i := idx; i < len(perm); i++ {
		perm[idx], perm[i] = perm[i], perm[idx]
		traverse(idx+1, perm, res)
		perm[idx], perm[i] = perm[i], perm[idx]
	}
}