/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        var map = new Dictionary<Node, Node>();
        Node current = head;
        // 將現有節點紀錄至集合
        while (current != null) {
            map[current] = new Node(current.val);
            current = current.next;
        }

        current = head;
        // 將集合內的節點依照原有節點關係進行連接
        while (current != null) {
            Node copy = map[current];
            copy.next = current.next != null ? map[current.next] : null;
            copy.random = current.random != null ? map[current.random] : null;
            current = current.next;
        }
        return map[head];
    }
}