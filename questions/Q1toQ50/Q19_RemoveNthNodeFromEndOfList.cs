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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        int count = 0;
        ListNode temp = head;

        // 計算 list 長度
        while (temp != null) {
            count++;
            temp = temp.next;
        }

        ListNode current = head, preceding = null;
        // 刪除的為第一個節點
        if (count - n == 0) {
            head = head.next;
        }
        else {
            // 移動至目標節點
            for (int i = 0; i < count - n; i++) {
                preceding = current;
                current = current.next;
            }
            // 跳過被刪除節點
            if (preceding != null) {
                preceding.next = current.next;
            }
        }
        return head;
    }
}