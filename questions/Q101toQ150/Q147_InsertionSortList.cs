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
    public ListNode InsertionSortList(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }

        ListNode front = new ListNode(int.MinValue);
        ListNode current = head;
        while (current != null) {
            ListNode next = current.next;
            ListNode previous = front;

            // 尋找比前面節點小的節點
            while (previous.next != null && previous.next.val <= current.val) {
                previous = previous.next;
            }
            // 更改節點順序
            current.next = previous.next;
            previous.next = current;
            current = next;
        }
        return front.next;
    }
}