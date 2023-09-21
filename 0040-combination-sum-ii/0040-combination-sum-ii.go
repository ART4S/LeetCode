package main

import "sort"

func combinationSum2(candidates []int, target int) (result [][]int) {
	newCand := make([]int, 0)

	for _, c := range candidates {
		if c <= target {
			newCand = append(newCand, c)
		}
	}

	sort.Ints(newCand)

	comb := make([]int, 0)

	backtrack(0, 0, target, newCand, &comb, &result)

	return
}

func backtrack(idx, currentSum, targetSum int, cand []int, comb *[]int, result *[][]int) {
	if currentSum == targetSum {
		*result = append(*result, append([]int(nil), *comb...))
		return
	}

	for i := idx; i < len(cand); i++ {
		if i != idx && cand[i] == cand[i-1] {
			continue
		}
		if nextSum := currentSum + cand[i]; nextSum <= targetSum {
			*comb = append(*comb, cand[i])
			backtrack(i+1, nextSum, targetSum, cand, comb, result)
			*comb = (*comb)[:len(*comb)-1]
		} else {
			break
		}
	}
}