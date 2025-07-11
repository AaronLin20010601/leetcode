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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // 相加總數的 list 和進位數
        ListNode head = new ListNode(0);
        ListNode current = head;
        int carry = 0;

        // 相加迴圈
        while (l1 != null || l2 != null || carry != 0) {
            // 取得數字並相加取進位數
            int val1 = l1 != null ? l1.val : 0;
            int val2 = l2 != null ? l2.val : 0;
            int sum = val1 + val2 + carry;
            int digit = sum % 10;
            carry = sum / 10;

            // 進到下一位數
            current.next = new ListNode(digit);
            current = current.next;
            if (l1 != null) {
                l1 = l1.next;
            }
            if (l2 != null) {
                l2 = l2.next;
            }
        }
        return head.next;
    }
}