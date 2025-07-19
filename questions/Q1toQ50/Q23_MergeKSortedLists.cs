/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        var queue = new PriorityQueue<ListNode, int>();

        // 將一元陣列節點加入 queue
        foreach (var list in lists) {
            if (list != null) {
                queue.Enqueue(list, list.val);
            }
        }

        var head = new ListNode(0);
        var current = head;
        // 每次從 queue 中取出最小值,直至取盡
        while (queue.Count > 0) {
            var newNode = queue.Dequeue();
            current.next = newNode;
            current = current.next;

            if (newNode.next != null) {
                queue.Enqueue(newNode.next, newNode.next.val);
            }
        }
        return head.next;
    }
}