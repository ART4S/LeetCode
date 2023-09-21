func exist(board [][]byte, word string) bool {
	n, m, wlen := len(board), len(board[0]), len(word)

	var search func(i, j, k int) bool

	search = func(i, j, k int) bool {
		if k == wlen {
			return true
		}

		if i < 0 || j < 0 || i == n || j == m || board[i][j] != word[k] || board[i][j] == 0 {
			return false
		}

		board[i][j] = 0

		switch {
		case search(i+1, j, k+1):
			return true
		case search(i-1, j, k+1):
			return true
		case search(i, j+1, k+1):
			return true
		case search(i, j-1, k+1):
			return true
		}

		board[i][j] = word[k]

		return false
	}

	for i := 0; i < n; i++ {
		for j := 0; j < m; j++ {
			if board[i][j] == word[0] && search(i, j, 0) {
				return true
			}
		}
	}

	return false
}