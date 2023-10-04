func canCompleteCircuit(gas []int, cost []int) int {
	n := len(gas)
	sum := 0
	count := 0
	ind := 0

	for i := 0; i < 2*n; i++ {
		sum += gas[i%n] - cost[i%n]

		if sum < 0 {
			sum, count = 0, 0
		} else {
			if count == 0 {
				ind = i
			}

			count++

			if count == n {
				return ind
			}
		}
	}

	return -1
}