func subsets(nums []int) [][]int {
	res := make([][]int, 0)
	cur := make([]int, 0)
	traverse(nums, 0, &cur, &res)
	return res
}

func traverse(nums []int, start int, cur *[]int, res *[][]int) {
	*res = append(*res, append([]int{}, (*cur)...))

	for i := start; i < len(nums); i++ {
		*cur = append(*cur, nums[i])
		traverse(nums, i+1, cur, res)
		*cur = (*cur)[:len(*cur)-1]
	}
}