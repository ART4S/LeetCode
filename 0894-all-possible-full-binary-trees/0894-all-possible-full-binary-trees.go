func allPossibleFBT(n int) []*TreeNode {
	memo := make([][][]*TreeNode, n+1)

	for i := range memo {
		memo[i] = make([][]*TreeNode, n+1)
	}

	var solve func(int, int) []*TreeNode

	solve = func(l, r int) []*TreeNode {
		if l == r {
			return []*TreeNode{{}}
		}

		if memo[l][r] == nil {
			res := make([]*TreeNode, 0)

			for p := l + 1; p < r; p++ {
				for _, ln := range solve(l, p-1) {
					for _, rn := range solve(p+1, r) {
						res = append(res, &TreeNode{
							Left:  ln,
							Right: rn,
						})
					}
				}
			}

			memo[l][r] = res
		}

		return memo[l][r]
	}

	return solve(1, n)
}