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
    public ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null || k == 1) return head;

        ListNode temp = new ListNode(0, head);
        ListNode previousEndNode = temp;

        while (true) {
            // 檢查節點是否足夠反轉
            ListNode kthNode = GetKthNode(previousEndNode, k);
            if (kthNode == null) {
                break;
            }

            // 反轉當前節點組
            ListNode first = previousEndNode.next;
            ListNode nextFirstNode = kthNode.next;
            Reverse(first, kthNode.next);

            // 重指方向並移動至下一節點組
            previousEndNode.next = kthNode;
            first.next = nextFirstNode;
            previousEndNode = first;
        }
        return temp.next;
    }
    // 取得第 k 個節點
    private ListNode GetKthNode(ListNode current, int k) {
        while (current != null && k > 0) {
            current = current.next;
            k--;
        }
        return current;
    }
    // 範圍內數量節點反轉
    private void Reverse(ListNode first, ListNode last) {
        ListNode previous = last;
        while (first != last) {
            ListNode temp = first.next;
            first.next = previous;
            previous = first;
            first = temp;
        }
    }
}