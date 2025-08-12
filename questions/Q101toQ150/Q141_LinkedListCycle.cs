/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        ListNode fast = head, slow = head;
        // 使用快慢指針檢查
        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
            // 到達同一點代表有閉環
            if (fast == slow) {
                return true;
            }
        }
        return false;
    }
}