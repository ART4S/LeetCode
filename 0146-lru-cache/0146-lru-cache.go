type LRUCache struct {
	capacity     int
	items        map[int]*Item
	headSentinel *Item
	tailSentinel *Item
}

type Item struct {
	key   int
	value int
	prev  *Item
	next  *Item
}

func Constructor(capacity int) LRUCache {
	headS := &Item{}
	tailS := &Item{}
	headS.next = tailS
	tailS.prev = headS

	return LRUCache{capacity, make(map[int]*Item, capacity), headS, tailS}
}

func (this *LRUCache) Get(key int) int {
	if item, ok := this.items[key]; ok {
		this.remove(item)
		this.addLast(item)
		return item.value
	}

	return -1
}

func (this *LRUCache) Put(key int, value int) {
	item, ok := this.items[key]
	if ok {
		item.value = value
		this.remove(item)
	} else {
		if len(this.items) == this.capacity {
			this.evict()
		}

		item = &Item{key: key, value: value}
		this.items[key] = item
	}

	this.addLast(item)
}

func (this *LRUCache) addLast(item *Item) {
	tail := this.tailSentinel.prev

	tail.next = item
	item.prev = tail

	item.next = this.tailSentinel
	this.tailSentinel.prev = item
}

func (this *LRUCache) remove(item *Item) {
	item.prev.next = item.next
	item.next.prev = item.prev
}

func (this *LRUCache) evict() {
	first := this.headSentinel.next
	delete(this.items, first.key)
	this.remove(first)
}
