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
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }

        ListNode start = new ListNode(0, head);
        ListNode previous = start, current = head;
        while (current != null) {
            // 檢查是否有重複值
            if (current.next != null && current.val == current.next.val) {
                int value = current.val;

                // 移除所有該值節點
                while (current != null && current.val == value) {
                    current = current.next;
                }
                previous.next = current;
            }
            else {
                previous = previous.next;
                current = current.next;
            }
        }
        return start.next;
    }
}