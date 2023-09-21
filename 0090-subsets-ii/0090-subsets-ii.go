type NumCount struct {
	value int
	count int
}

func subsetsWithDup(nums []int) [][]int {
	countMap := make(map[int]int)
	for _, n := range nums {
		countMap[n]++
	}
	count := make([]NumCount, 0)
	for k, v := range countMap {
		count = append(count, NumCount{k, v})
	}

	res := make([][]int, 0)
	sub := make([]int, 0)
	traverse(0, count, &sub, &res)

	return res
}

func traverse(idx int, nums []NumCount, sub *[]int, res *[][]int) {
	*res = append(*res, append([]int(nil), *sub...))

	for i := idx; i < len(nums); i++ {
		for j := 0; j < nums[i].count; j++ {
			*sub = append(*sub, nums[i].value)
			traverse(i+1, nums, sub, res)
		}
		*sub = (*sub)[:len(*sub)-nums[i].count]
	}
}