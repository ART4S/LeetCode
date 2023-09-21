func minEatingSpeed(piles []int, h int) int {
	maxPile := math.MinInt

	for _, p := range piles {
		maxPile = max(maxPile, p)
	}

	l, r := 1, maxPile

	for l < r {
		m := l + (r-l)/2

		if check(piles, h, m) {
			r = m
		} else {
			l = m + 1
		}
	}

	return l
}

func check(piles []int, totalHours int, bananasPerHour int) bool {
	for _, p := range piles {
		spentHours := int(math.Ceil(float64(p) / float64(bananasPerHour)))
		totalHours -= spentHours
		if totalHours < 0 {
			return false
		}
	}
	return true
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}