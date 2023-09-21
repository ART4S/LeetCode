func letterCombinations(digits string) (result []string) {
	if len(digits) == 0 {
		return nil
	}

	letters := map[byte]string{
		'2': "abc",
		'3': "def",
		'4': "ghi",
		'5': "jkl",
		'6': "mno",
		'7': "pqrs",
		'8': "tuv",
		'9': "wxyz",
	}	
	comb := make([]byte, 0)

	var dfs func(int)

	dfs = func(idx int) {
		if idx == len(digits) {
			result = append(result, string(append([]byte(nil), comb...)))
			return
		}

		for _, l := range letters[digits[idx]] {
			comb = append(comb, byte(l))
			dfs(idx + 1)
			comb = comb[:len(comb)-1]
		}
	}

	dfs(0)

	return
}