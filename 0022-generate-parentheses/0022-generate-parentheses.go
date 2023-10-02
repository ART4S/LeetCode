func generateParenthesis(n int) []string {
	res := make([]string, 0)
	generate(0, 0, n, make([]rune, 0), &res)
	fmt.Println(res)
	return res
}

func generate(open int, closed int, n int, cur []rune, res *[]string) {
	if open == n && closed == n {
		*res = append(*res, string(cur))
		return
	}
	if open < n {
		generate(open+1, closed, n, append(cur, '('), res)
	}
	if closed < open {
		generate(open, closed+1, n, append(cur, ')'), res)
	}
}