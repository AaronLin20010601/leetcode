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
    public bool HasPathSum(TreeNode root, int targetSum) {
        return IsTargetSum(root, targetSum, 0);
    }
    private bool IsTargetSum(TreeNode node, int targetSum, int currentSum) {
        if (node == null) {
            return false;
        }
        currentSum += node.val;

        // 檢查葉節點處總和是否符合
        if (node.left == null && node.right == null) {
            return currentSum == targetSum;
        }
        // 遞迴檢查左右子樹路徑
        return IsTargetSum(node.left, targetSum, currentSum) || IsTargetSum(node.right, targetSum, currentSum);
    }
}