func lastStoneWeightII(stones []int) int {
	totalSum := 0

	for _, s := range stones {
		totalSum += s
	}

	dp := make([][]bool, len(stones)+1)

	for i := range dp {
		dp[i] = make([]bool, totalSum/2+1)

		dp[i][0] = true
	}

	closest := 0

	for sum := 1; sum <= totalSum/2; sum++ {
		for i := 1; i <= len(stones); i++ {
			dp[i][sum] = dp[i-1][sum]

			if sum >= stones[i-1] {
				dp[i][sum] = dp[i][sum] || dp[i-1][sum-stones[i-1]]
			}

			if dp[i][sum] && sum > closest {
				closest = sum
			}
		}
	}

	return totalSum - 2*closest
}