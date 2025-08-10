/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) {
            return null;
        }
        var map = new Dictionary<Node, Node>();
        return Clone(node, map);
    }
    private Node Clone(Node node, Dictionary<Node, Node> map) {
        // 跳過已經複製的節點
        if (map.ContainsKey(node)) {
            return map[node];
        }
        // 複製節點並遞迴處理鄰近節點
        var copy = new Node(node.val);
        map[node] = copy;
        foreach (var neighbor in node.neighbors) {
            copy.neighbors.Add(Clone(neighbor, map));
        }
        return copy;
    }
}