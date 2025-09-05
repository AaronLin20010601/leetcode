/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void DeleteNode(ListNode node) {
        // 更改值為下個節點的值,並跳過該節點
        node.val = node.next.val;
        node.next = node.next.next;
    }
}