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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if (left == right) {
            return head;
        }

        ListNode newHead = new ListNode(0, head);
        ListNode previous = newHead;
        // 移動至要反轉的目標節點
        for (int i = 0; i < left - 1; i++) {
            previous = previous.next;
        }

        ListNode first = previous.next;
        ListNode second = null;
        // 對目標範圍內節點進行反轉
        for (int i = 0; i < right - left; i++) {
            second = first.next;
            first.next = second.next;
            second.next = previous.next;
            previous.next = second;
        }
        return newHead.next;
    }
}