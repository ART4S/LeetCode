func numDecodings(s string) (res int) {
	dp := make([]int, len(s) + 1)

	dp[0] = 1

	for i := 0; i < len(s); i++ {
		if s[i] != '0' {
			dp[i+1] += dp[i]
			if i+1 < len(s) && (s[i] == '1' || s[i] == '2' && s[i+1] < '7') {
				dp[i+2] += dp[i]
			}
		}
	}

	return dp[len(dp)-1]
}