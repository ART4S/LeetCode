func carFleet(target int, position []int, speed []int) int {
	type ps struct {
		position, speed int
	}

	pos := make([]ps, len(position), len(position))

	for i, p := range position {
		pos[i] = ps{p, speed[i]}
	}

	sort.SliceStable(pos, func(i, j int) bool {
		return pos[i].position < pos[j].position
	})

	stack := make([]float64, 0, len(pos))

	for _, ps := range pos {
		stack = append(stack, float64(target-ps.position)/float64(ps.speed))
	}

	res := 0

	for len(stack) > 0 {
		res++

		cur := stack[len(stack)-1]

		stack = stack[:len(stack)-1]

		for len(stack) > 0 && stack[len(stack)-1] <= cur {
			stack = stack[:len(stack)-1]
		}
	}

	return res
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
