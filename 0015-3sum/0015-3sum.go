func threeSum(nums []int) [][]int {
	sort.Slice(nums, func(i, j int) bool {
		return nums[i] < nums[j]
	})

    n := len(nums)
	res := make([][]int, 0)

	for i := 0; i < n - 2; i++ {
        if i != 0 && nums[i] == nums[i - 1] {
            continue
        }

		l := i + 1
		r := n - 1

		for l < r {
            sum := nums[i] + nums[l] + nums[r]
            
			if sum == 0 {
                t := []int{nums[i], nums[l], nums[r]}
                
				res = append(res, t)

				for l < r && nums[l] == t[1] {
					l++
				}

				for l < r && nums[r] == t[2] {
					r--
				}
			} else if sum > 0 {
				r--
			} else {
				l++
			}
		}
	}

	return res
}