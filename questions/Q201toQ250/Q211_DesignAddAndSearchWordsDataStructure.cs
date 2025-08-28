public class WordDictionary {
    // 使用樹狀節點陣列來進行字串紀錄
    private class Node {
        // 對應 a~z 的字元子節點
        public Node[] next = new Node[26];
        public bool isEnd;
    }
    private readonly Node root = new Node();

    public WordDictionary() {
        
    }
    
    public void AddWord(string word) {
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
        return DFSSearch(word, 0, root);
    }
    // 使用深度優先搜尋遞迴檢查字串
    private bool DFSSearch(string word, int pos, Node node) {
        if (node == null) {
            return false;
        }
        if (pos == word.Length) {
            return node.isEnd;
        }

        char ch = word[pos];
        // 若為通用字元則檢查所有分支
        if (ch == '.') {
            for (int i = 0; i < 26; i++) {
                if (node.next[i] != null && DFSSearch(word, pos + 1, node.next[i])) {
                    return true;
                }
            }
            return false;
        }
        // 進行下一輪遞迴檢查
        else {
            int index = ch - 'a';
            return DFSSearch(word, pos + 1, node.next[index]);
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */