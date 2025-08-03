/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) {
            return null;
        }
        Node current = root;

        while (current != null) {
            // 取每層最左邊節點
            Node levelHead = new Node(0), tail = levelHead;

            // 檢查當層每一節點
            while (current != null) {
                // 連接下一層的左右節點
                if (current.left != null) {
                    tail.next = current.left;
                    tail = tail.next;
                }
                if (current.right != null) {
                    tail.next = current.right;
                    tail = tail.next;
                }
                // 移動至同層下一個節點
                current = current.next;
            }
            // 移動至下一層
            current = levelHead.next;
        }
        return root;
    }
}