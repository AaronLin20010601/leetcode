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
    public ListNode SwapPairs(ListNode head) {
        ListNode temp = new ListNode(0, head);
        ListNode previous = temp;

        // 有兩個或以上節點時則兩節點互換
        while (previous.next != null && previous.next.next != null) {
            ListNode first = previous.next;
            ListNode second = first.next;

            // 交換節點
            first.next = second.next;
            second.next = first;
            previous.next = second;
            previous = first;
        }
        return temp.next;
    }
}