func findDuplicates(nums []int) []int {
	for i := range nums {
		for nums[i] != nums[nums[i]-1] {
			temp := nums[nums[i]-1]
			nums[nums[i]-1] = nums[i]
			nums[i] = temp
		}
	}

	res := make([]int, 0)

	for i := range nums {
		if nums[i]-1 != i {
			res = append(res, nums[i])
		}
	}

	return res
}