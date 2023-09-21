func minWindow(s string, t string) string {
	count := map[byte]int{}

	for i := 0; i < len(t); i++ {
		count[t[i]]++
	}

	l, r := -1, -1
	ml, mr := 0, math.MaxInt
	tcount := 0

	for r < len(s) {
		if tcount == len(count) {
			l++
			if _, ok := count[s[l]]; ok {
				count[s[l]]++

				if count[s[l]] == 1 {
					tcount--
				}
			}
		} else {
			r++
			if r < len(s) {
				if _, ok := count[s[r]]; ok {
					count[s[r]]--

					if count[s[r]] == 0 {
						tcount++
					}
				}
			}
		}

		if tcount == len(count) && r-l < mr-ml {
			ml, mr = l+1, r+1
		}

		if l == r {
			break
		}
	}

	if mr == math.MaxInt {
		return ""
	}

	return string(s[ml:mr])
}