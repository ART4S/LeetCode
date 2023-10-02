func characterReplacement(s string, k int) int {
	uniqueChars := map[byte]bool{}

	for _, c := range s {
		uniqueChars[byte(c)] = true
	}

	maxLen := 0

	for uc := range uniqueChars {
		for l, r, w := 0, 0, 0; r < len(s); r++ {
			if s[r] != uc {
				if w < k {
					w++
				} else {
					for s[l] == uc {
						l++
					}
					l++
				}
			}
			maxLen = max(maxLen, r-l+1)
		}
	}

	return maxLen
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}