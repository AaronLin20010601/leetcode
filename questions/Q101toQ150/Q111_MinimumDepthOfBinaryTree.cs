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
    public int MinDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }
        if (root.left == null && root.right == null) {
            return 1;
        }

        // 遞迴檢查左右子樹高度
        int leftDepth = MinDepth(root.left);
        int rightDepth = MinDepth(root.right);
        if (root.left == null || root.right == null) {
            return 1 + leftDepth + rightDepth;
        }
        return 1 + Math.Min(leftDepth, rightDepth);
    }
}