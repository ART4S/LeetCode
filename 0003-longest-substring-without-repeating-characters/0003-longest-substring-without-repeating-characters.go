func lengthOfLongestSubstring(s string) int {
	positions, start, maxLen := make(map[byte]int), 0, -1

	for i := 0; i < len(s); i++ {
		if pos, ok := positions[s[i]]; ok && pos >= start {
			start = pos + 1
		}

		positions[s[i]], maxLen = i, max(maxLen, i-start)
	}

	return maxLen + 1
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}