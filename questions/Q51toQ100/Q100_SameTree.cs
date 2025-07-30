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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        // 同時為空節點則正確
        if (p == null && q == null) {
            return true;
        }
        // 只有一者為空節點則不相同
        if (p == null || q == null) {
            return false;
        }
        // 值不相同
        if (p.val != q.val) {
            return false;
        }
        // 遞迴檢查左子樹和右子樹
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}