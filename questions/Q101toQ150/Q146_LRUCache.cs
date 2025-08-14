public class LRUCache {
    // 使用函式庫 linked list 進行資料讀寫
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int val)>> _map;
    private readonly LinkedList<(int key, int val)> _list;

    public LRUCache(int capacity) {
        _capacity = capacity;
        _map = new Dictionary<int, LinkedListNode<(int key, int val)>>(capacity);
        _list = new LinkedList<(int key, int val)>();
    }
    
    public int Get(int key) {
        if (!_map.TryGetValue(key, out var node)) {
            return -1;
        }
        // 取得現有點並移動至最前端
        _list.Remove(node);
        _list.AddFirst(node);
        return node.Value.val;
    }
    
    public void Put(int key, int value) {
        // 若已有該 key 值則更新值並移動至最前端
        if (_map.TryGetValue(key, out var node)) {
            node.Value = (key, value);
            _list.Remove(node);
            _list.AddFirst(node);
        }
        else {
            var newNode = new LinkedListNode<(int key, int val)>((key, value));
            _list.AddFirst(newNode);
            _map[key] = newNode;

            // 超過容量則移除最後面的點
            if (_map.Count > _capacity) {
                var lru = _list.Last;
                _list.RemoveLast();
                _map.Remove(lru.Value.key);
            }
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */