func mergeTriplets(triplets [][]int, tar []int) bool {
	ans := [3]bool{}

	for _, tri := range triplets {
		if tri[0] <= tar[0] && tri[1] <= tar[1] && tri[2] <= tar[2] {
			for i := 0; i < 3; i++ {
				ans[i] = ans[i] || tri[i] == tar[i]
			}
		}
	}

	return ans[0] && ans[1] && ans[2]
}