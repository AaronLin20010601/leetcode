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
    public bool IsValidBST(TreeNode root) {
        return CheckValid(root, long.MinValue, long.MaxValue);
    }
    private bool CheckValid(TreeNode node, long min, long max) {
        if (node == null) {
            return true;
        }
        // 檢查正確位於左子樹或右子樹值區間
        if (node.val <= min || node.val >= max) {
            return false;
        }
        // 遞迴檢查各自左右子樹節點
        return CheckValid(node.left, min, node.val) && CheckValid(node.right, node.val, max);
    }
}