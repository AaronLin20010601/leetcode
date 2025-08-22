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
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode newHead = new ListNode(0, head);
        ListNode previous = newHead;

        while (head != null) {
            // 跳過對應節點
            if (head.val == val) {
                previous.next = head.next;
            }
            else {
                previous = head;
            }
            head = head.next;
        }
        return newHead.next;
    }
}