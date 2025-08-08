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
    public int SumNumbers(TreeNode root) {
        return GetSum(root, 0);
    }
    private int GetSum(TreeNode node, int sum) {
        if (node == null) {
            return 0;
        }

        // 計算當前總和並檢查是否為葉節點
        sum = sum * 10 + node.val;
        if (node.left == null && node.right == null) {
            return sum;
        }
        // 遞迴檢查左右子樹數字
        return GetSum(node.left, sum) + GetSum(node.right, sum);
    }
}