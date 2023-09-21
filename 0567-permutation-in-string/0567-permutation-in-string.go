func checkInclusion(s1 string, s2 string) bool {
	freq, count := map[byte]int{}, 0

	for i := range s1 {
		freq[s1[i]]++
		if freq[s1[i]] == 1 {
			count++
		}
	}

	for i := 0; i < len(s2); i++ {
		if i >= len(s1) {
			freq[s2[i-len(s1)]]++

			if freq[s2[i-len(s1)]] == 1 {
				count++
			}
		}

		freq[s2[i]]--

		if freq[s2[i]] == 0 {
			count--
			if count == 0 {
				return true
			}
		}
	}

	return false
}