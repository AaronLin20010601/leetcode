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
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null) {
            return;
        }

        // 使用快慢指針找出 list 中間點
        ListNode slow = head, fast = head;
        while (fast.next != null && fast.next.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }

        // 將 list 分成前半段和後半段
        ListNode firstHalf = head;
        ListNode secondHalf = slow.next;
        slow.next = null;
        // 將後半段 list 反轉
        secondHalf = ReverseList(secondHalf);

        // 將前半段和後半段交叉合併
        while (secondHalf != null) {
            ListNode firstNext = firstHalf.next, secondNext = secondHalf.next;
            firstHalf.next = secondHalf;
            secondHalf.next = firstNext;
            firstHalf = firstNext;
            secondHalf = secondNext;
        }
    }
    private ListNode ReverseList(ListNode node) {
        ListNode previous = null;
        while (node != null) {
            ListNode next = node.next;
            node.next = previous;
            previous = node;
            node = next;
        }
        return previous;
    }
}