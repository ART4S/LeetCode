func numIslands(grid [][]byte) (res int) {
	n, m := len(grid), len(grid[0])

	var traverse func(int, int)

	traverse = func(i, j int) {
		if i < 0 || j < 0 || i == n || j == m || grid[i][j] == '0' {
			return
		}

		grid[i][j] = '0'

		traverse(i+1, j)
		traverse(i-1, j)
		traverse(i, j+1)
		traverse(i, j-1)
	}

	for i := 0; i < n; i++ {
		for j := 0; j < m; j++ {
			if grid[i][j] == '1' {
				traverse(i, j)
				res++
			}
		}
	}

	return
}