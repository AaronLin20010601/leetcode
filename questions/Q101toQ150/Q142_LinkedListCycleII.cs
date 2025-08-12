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
    public ListNode DetectCycle(ListNode head) {
        if (head == null || head.next == null) {
            return null;
        }

        ListNode fast = head, slow = head;
        // 使用快慢指針檢查
        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;

            // 到達同一點代表有閉環
            if (fast == slow) {
                fast = head;
                // 慢指針本輪剩餘步數走完即為循環點
                while (fast != slow) {
                    fast = fast.next;
                    slow = slow.next;
                }
                return slow;
            }
        }
        return null;
    }
}