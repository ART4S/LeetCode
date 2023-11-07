func isMatch(s string, p string) bool {
	memo := make([][]int, len(s)+1)

	for i := range memo {
		memo[i] = make([]int, len(p)+1)

		for j := range memo[i] {
			memo[i][j] = -1
		}
	}

	var solve func(int, int) bool

	solve = func(i, j int) bool {
		if i == len(s) && j == len(p) {
			return true
		}

		if memo[i][j] == -1 {
			memo[i][j] = 0

			if i == len(s) || j == len(p) {
				if i == len(s) && j+1 < len(p) && p[j+1] == '*' {
					if j+1 < len(p) && p[j+1] == '*' {
						if solve(i, j+2) {
							memo[i][j] = 1
						}
					}
				}
			} else if j+1 < len(p) && p[j+1] == '*' {
				if p[j] == '.' || p[j] == s[i] {
					if solve(i, j+2) || solve(i+1, j+2) || solve(i+1, j) {
						memo[i][j] = 1
					}
				} else if solve(i, j+2) {
					memo[i][j] = 1
				}
			} else if p[j] == '.' || p[j] == s[i] {
				if solve(i+1, j+1) {
					memo[i][j] = 1
				}
			}
		}

		return memo[i][j] == 1
	}

	return solve(0, 0)
}