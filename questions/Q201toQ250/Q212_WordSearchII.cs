public class Solution {
    // 使用樹狀節點陣列來進行字串紀錄
    private class Node {
        // 對應 a~z 的字元子節點
        public Node[] next = new Node[26];
        public string word = null!;
    }

    // 對所有可能字串路徑建立樹狀結構
    private Node BuildTree(string[] words) {
        Node root = new Node();

        foreach (var w in words) {
            Node node = root;
            foreach (var ch in w) {
                // 將字元子節點放入對應陣列位置
                int index = ch - 'a';

                if (node.next[index] == null) {
                    node.next[index] = new Node();
                }
                node = node.next[index];
            }
            // 紀錄為當下字串
            node.word = w;
        }
        return root;
    }

    public IList<string> FindWords(char[][] board, string[] words) {
        int rowLength = board.Length, colLength = board[0].Length;
        Node root = BuildTree(words);
        HashSet<string> result = new HashSet<string>();
        int[][] directions = new int[][] {
            new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, 1}, new int[] {0, -1}
        };

        // 使用深度優先搜尋遞迴檢查是否有符合單字
        void DFSSearch(int rowIndex, int colIndex, Node parent) {
            char ch = board[rowIndex][colIndex];
            // 若為已經走過的路徑則返回
            if (ch == '#') {
                return;
            }

            int index = ch - 'a';
            Node node = parent.next[index];
            // 若無子節點則返回
            if (node == null) {
                return;
            }

            // 紀錄字串並重置
            if (node.word != null) {
                result.Add(node.word);
                node.word = null;
            }

            // 標記為已經過
            board[rowIndex][colIndex] = '#';
            foreach (var direction in directions) {
                int newRowIndex = rowIndex + direction[0], newColIndex = colIndex + direction[1];
                if (newRowIndex >= 0 && newRowIndex < rowLength && newColIndex >= 0 && newColIndex < colLength) {
                    // 繼續往未超出邊界範圍搜尋
                    DFSSearch(newRowIndex, newColIndex, node);
                }
            }
            // 返回上一輪
            board[rowIndex][colIndex] = ch;

            // 當前節點無子節點,所屬字串也已記錄過則該路線停止
            bool hasChild = false;
            for (int alphabet = 0; alphabet < 26; alphabet++) {
                if (node.next[alphabet] != null) {
                    hasChild = true;
                    break;
                }
            }
            if (!hasChild && node.word == null) {
                parent.next[index] = null;
            }
        }

        for (int i = 0; i < rowLength; i++) {
            for (int j = 0; j < colLength; j++) {
                DFSSearch(i, j, root);
            }
        }
        return new List<string>(result);
    }
}