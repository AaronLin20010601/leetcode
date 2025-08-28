public class Trie {
    private class Node {
        // 對應 a~z 的字元子節點
        public Node[] next = new Node[26];
        public bool isEnd;
    }
    private readonly Node root = new Node();

    public Trie() {
        
    }
    
    public void Insert(string word) {
        Node current = root;

        foreach (char ch in word) {
            // 將字元子節點放入對應陣列位置
            int index = ch - 'a';

            if (current.next[index] == null) {
                current.next[index] = new Node();
            }
            current = current.next[index];
        }
        // 標記為字串結束
        current.isEnd = true;
    }
    
    public bool Search(string word) {
        // 檢查節點是否對應且為字串結束
        Node node = FindNode(word);
        return node != null && node.isEnd;
    }
    
    public bool StartsWith(string prefix) {
        // 檢查範圍內節點是否對應
        return FindNode(prefix) != null;
    }
    // 檢查節點是否對應
    private Node FindNode(string s) {
        Node current = root;

        foreach (char ch in s) {
            int index = ch - 'a';

            // 沒有相對應節點
            if (current.next[index] == null) {
                return null;
            }
            current = current.next[index];
        }
        return current;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */