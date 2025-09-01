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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null) {
            return null;
        }

        // 遞迴左右根並互換左右子樹
        TreeNode leftTree = InvertTree(root.left);
        TreeNode rightTree = InvertTree(root.right);
        root.left = rightTree;
        root.right = leftTree;

        return root;
    }
}