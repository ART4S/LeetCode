type WordDictionary struct {
	root *Node
}

type Node struct {
	symbol byte
	next   map[byte]*Node
	end    bool
}

func Constructor() WordDictionary {
	return WordDictionary{&Node{' ', make(map[byte]*Node), false}}
}

func (this *WordDictionary) AddWord(word string) {
	cur := this.root

	for i := 0; i < len(word); i++ {
		if cur.next == nil {
			cur.next = make(map[byte]*Node)
		}

		symbol := word[i]
		next, ok := cur.next[symbol]
		if !ok {
			next = &Node{symbol, nil, false}
			cur.next[symbol] = next
		}

		cur = next
	}

	cur.end = true
}

func (this *WordDictionary) Search(word string) bool {
	return this.SearchRecursively(&word, this.root, 0)
}

func (this *WordDictionary) SearchRecursively(word *string, root *Node, start int) bool {
	for i := start; i < len(*word); i++ {
		if root.next == nil {
			return false
		}

		symbol := (*word)[i]
		if symbol == '.' {
			for _, n := range root.next {
				if this.SearchRecursively(word, n, i+1) {
					return true
				}
			}

			return false
		}

		next, ok := root.next[symbol]
		if !ok {
			return false
		}

		root = next
	}

	return root.end
}