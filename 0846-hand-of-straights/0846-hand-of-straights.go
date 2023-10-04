func isNStraightHand(hand []int, groupSize int) bool {
	if len(hand)%groupSize != 0 {
		return false
	}

	count := make(map[int]int)
	cards := make([]int, 0)

	for _, c := range hand {
		if _, ok := count[c]; !ok {
			cards = append(cards, c)
		}
		count[c]++
	}

	sort.Slice(cards, func(i, j int) bool {
		return cards[i] < cards[j]
	})

	for i := 0; i < len(cards); i++ {
		if count[cards[i]] > 0 {
			gn := i + groupSize
			if gn > len(cards) {
				return false
			} else {
				for j := i + 1; j < gn; j++ {
					if cards[j-1] != cards[j]-1 || count[cards[i]] > count[cards[j]] {
						return false
					} else {
						count[cards[j]] -= count[cards[i]]
					}
				}
			}
		}
	}

	return true
}