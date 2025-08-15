/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        ListNode currentA = headA, currentB = headB;

        // 若兩 list 有交點則必會到達同一點
        while (currentA != currentB) {
            currentA = (currentA == null) ? headB : currentA.next;
            currentB = (currentB == null) ? headA : currentB.next;
        }
        return currentA;
    }
}