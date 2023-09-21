func findDuplicate(nums []int) int {
	m := make([]bool, len(nums)+1)

	for _, n := range nums {
		if m[n] {
			return n
		}

		m[n] = true
	}

	return -1
}