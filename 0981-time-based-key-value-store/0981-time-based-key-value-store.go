type TimeMap struct {
	store map[string][]TimeMapValue
}

type TimeMapValue struct {
	timestamp int
	value     string
}

func Constructor() TimeMap {
	return TimeMap{map[string][]TimeMapValue{}}
}

func (this *TimeMap) Set(key string, value string, timestamp int) {
	arr, ok := this.store[key]

	if !ok {
		this.store[key] = []TimeMapValue{{timestamp, value}}
		return
	}

	this.store[key] = append(arr, TimeMapValue{timestamp, value})
}

func (this *TimeMap) Get(key string, timestamp int) string {
	arr, ok := this.store[key]

	if !ok {
		return ""
	}

	l, r := 0, len(arr)-1

	for l < r {
		m := l + (r-l)/2

		if arr[m].timestamp > timestamp {
			r = m
		} else {
			l = m + 1
		}
	}

	if arr[l].timestamp <= timestamp {
		return arr[l].value
	}
    
	if l > 0 && arr[l-1].timestamp <= timestamp {
		return arr[l-1].value
	}

	return ""
}