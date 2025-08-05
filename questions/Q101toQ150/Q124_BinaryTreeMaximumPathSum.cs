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
    private int maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        MaxGain(root);
        return maxSum;
    }
    private int MaxGain(TreeNode node) {
        if (node == null) {
            return 0;
        }
        // 檢查左右子樹的最大增加值
        int leftGain = Math.Max(MaxGain(node.left), 0);
        int rightGain = Math.Max(MaxGain(node.right), 0);

        // 目前節點作為中繼點的加總值
        int currentSum = node.val + leftGain + rightGain;
        maxSum = Math.Max(maxSum, currentSum);
        // 將目前最大加總值回溯至上一層
        return node.val + Math.Max(leftGain, rightGain);
    }
}