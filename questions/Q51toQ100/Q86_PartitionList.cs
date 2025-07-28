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
    public ListNode Partition(ListNode head, int x) {
        // 使用兩個頭節點紀錄小於和大於等於的 list
        ListNode lessHead = new ListNode(0), greaterHead = new ListNode(0);
        ListNode less = lessHead, greater = greaterHead;

        while (head != null) {
            // 根據節點值加入對應 list
            if (head.val < x) {
                less.next = head;
                less = less.next;
            }
            else {
                greater.next = head;
                greater = greater.next;
            }
            head = head.next;
        }
        // 接上兩分類 list
        greater.next = null;
        less.next = greaterHead.next;
        return lessHead.next;
    }
}