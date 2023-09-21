func partition(s string) (result [][]string) {
	dp := make([][]bool, len(s))

	for i := 0; i < len(dp); i++ {
		dp[i] = make([]bool, len(s))
	}

	for i := 0; i < len(s); i++ {
		for j := 0; j <= i; j++ {
			if s[i] == s[j] && (i-j <= 2 || dp[j+1][i-1]) {
				dp[j][i] = true
			}
		}
	}

	part := make([]string, 0)

	var dfs func(int)

	dfs = func(idx int) {
		if idx == len(s) {
			result = append(result, append([]string(nil), part...))
			return
		}

		for i := idx; i < len(s); i++ {
			if dp[idx][i] {
				part = append(part, s[idx:(i+1)])
				dfs(i + 1)
				part = part[:len(part)-1]
			}
		}
	}

	dfs(0)

	return
}