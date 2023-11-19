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
        
		c := nums[i]

		l := i + 1
		r := n - 1

		for l < r {
			a := nums[l]
			b := nums[r]

			sum := a + b + c

			if sum == 0 {
				res = append(res, []int{a, b, c})

				for l < r && nums[l] == a {
					l++
				}

				for l < r && nums[r] == b {
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