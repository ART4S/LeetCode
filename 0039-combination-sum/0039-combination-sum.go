func combinationSum(candidates []int, target int) [][]int {
	dp := make([][][]int, target+1)

	for i := range dp {
		dp[i] = make([][]int, 0)
	}

	for _, c := range candidates {
		for i := c; i <= target; i++ {
			if i == c {
				dp[i] = append(dp[i], []int{c})
			} else {
				for _, comb := range dp[i-c] {
					dp[i] = append(dp[i], append(append([]int(nil), comb...), c))
				}
			}
		}
	}

	return dp[target]
}