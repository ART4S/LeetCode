func wordBreak(s string, wordDict []string) bool {
	dp := make([]bool, len(s)+1)

	dp[0] = true

	for i := 0; i < len(s); i++ {
		if dp[i] {
			for _, w := range wordDict {
				wn := i + len(w)
				if wn > len(s) {
					continue
				}
				if !dp[wn] {
					dp[wn] = true
					for j := 0; j < len(w); j++ {
						if w[j] != s[i+j] {
							dp[wn] = false
							break
						}
					}
				}
			}
		}
	}

	return dp[len(dp)-1]
}