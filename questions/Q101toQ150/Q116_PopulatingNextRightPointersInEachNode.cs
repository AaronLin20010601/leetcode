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

        // 取每層最左邊節點
        Node levelHead = root;

        while (levelHead.left != null) {
            Node currentHead = levelHead;

            while (currentHead != null) {
                // 連接下一層的左右節點
                currentHead.left.next = currentHead.right;
                // 將右節點連接至下一個左節點
                if (currentHead.next != null) {
                    currentHead.right.next = currentHead.next.left;
                }
                currentHead = currentHead.next;
            }
            // 移動至下一層
            levelHead = levelHead.left;
        }
        return root;
    }
}