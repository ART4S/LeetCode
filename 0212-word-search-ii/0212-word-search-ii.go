func findWords(board [][]byte, words []string) []string {
	dict := WordsDictionary{&Node{' ', make(map[byte]*Node), false}}

	for _, w := range words {
		dict.Add(w)
	}

	n, m := len(board), len(board[0])
	visited := make(map[Cell]bool)
	currentWord := make([]byte, 0)
	foundWords := make(map[string]bool)

	var traverse func(Cell, *Node)

	traverse = func(cur Cell, root *Node) {
		if cur.i < 0 || cur.i >= n || cur.j < 0 || cur.j >= m || visited[cur] {
			return
		}

		symbol := board[cur.i][cur.j]

		if next, ok := root.next[symbol]; !ok {
			return
		} else {
			root = next
		}

		currentWord = append(currentWord, symbol)
		visited[cur] = true

		if root.end {
			foundWords[string(currentWord)] = true
		}

		traverse(Cell{cur.i, cur.j + 1}, root)
		traverse(Cell{cur.i, cur.j - 1}, root)
		traverse(Cell{cur.i + 1, cur.j}, root)
		traverse(Cell{cur.i - 1, cur.j}, root)

		visited[cur] = false
		currentWord = currentWord[:len(currentWord)-1]
	}

	for i := 0; i < n; i++ {
		for j := 0; j < m; j++ {
			traverse(Cell{i, j}, dict.root)
		}
	}

	res := make([]string, 0)

	for k, _ := range foundWords {
		res = append(res, k)
	}

	return res
}

type WordsDictionary struct {
	root *Node
}

type Node struct {
	value byte
	next  map[byte]*Node
	end   bool
}

type Cell struct {
	i, j int
}

func (this *WordsDictionary) Add(word string) {
	cur := this.root

	for i := 0; i < len(word); i++ {
		next, ok := cur.next[word[i]]
		if !ok {
			next = &Node{word[i], make(map[byte]*Node), false}
			cur.next[next.value] = next
		}
		cur = next
	}

	cur.end = true
}