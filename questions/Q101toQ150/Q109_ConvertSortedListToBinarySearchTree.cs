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
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
        if (head == null) {
            return null;
        }
        return BuildTree(head, null);
    }
    private TreeNode BuildTree(ListNode head, ListNode tail) {
        if (head == tail) {
            return null;
        }
        
        // 用快慢雙指針定位中間數字當作根,左邊為左子樹,右邊為右子樹
        ListNode slow = head, fast = head;
        while (fast != tail && fast.next != tail) {
            slow = slow.next;
            fast = fast.next.next;
        }
        TreeNode root = new TreeNode(slow.val);

        root.left = BuildTree(head, slow);
        root.right = BuildTree(slow.next, tail);
        return root;
    }
}