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
    public ListNode OddEvenList(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }

        ListNode odd = head, even = head.next, evenHead = even;
        // 對奇偶數位置節點進行分類
        while (even != null && even.next != null) {
            // 集中奇數節點
            odd.next = even.next;
            odd = odd.next;
            // 集中偶數節點
            even.next = odd.next;
            even = even.next;
        }
        odd.next = evenHead;
        return head;
    }
}