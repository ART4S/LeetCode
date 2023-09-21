func maxProfit(prices []int) int {
	minPrice, maxProfit := math.MaxInt, math.MinInt

	for _, price := range prices {
		minPrice = min(minPrice, price)
		profit := price - minPrice
		maxProfit = max(maxProfit, profit)
	}

	return maxProfit
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}