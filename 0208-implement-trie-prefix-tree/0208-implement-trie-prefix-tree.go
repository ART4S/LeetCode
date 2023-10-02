type Trie struct {
	root *Node
}

type Node struct {
	symbol rune
	next   []*Node
	end    bool
}

func Constructor() Trie {
	return Trie{&Node{' ', make([]*Node, 26), false}}
}

func (this *Trie) Insert(word string) {
	cur := this.root

	for _, c := range word {
		i := c - 'a'
		if cur.next[i] == nil {
			cur.next[i] = &Node{c, make([]*Node, 26), false}
		}
		cur = cur.next[i]
	}

	cur.end = true
}

func (this *Trie) Search(word string) bool {
	cur := this.root

	for _, c := range word {
		i := c - 'a'
		if cur.next[i] == nil {
			return false
		}
		cur = cur.next[i]
	}

	return cur.end
}

func (this *Trie) StartsWith(prefix string) bool {
	cur := this.root

	for _, c := range prefix {
		i := c - 'a'
		if cur.next[i] == nil {
			return false
		}
		cur = cur.next[i]
	}

	return true
}