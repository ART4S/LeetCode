func search(nums []int, target int) int {
	l, r := 0, len(nums)-1

	for l < r {
		m := l + (r-l)/2
		if nums[m] < nums[l] && target > nums[r] {
			r = m
		} else if nums[m] > nums[r] && target < nums[l] {
			l = m + 1
		} else if nums[m] >= target {
			r = m
		} else {
			l = m + 1
		}
	}

	if nums[l] == target {
		return l
	}

	return -1
}