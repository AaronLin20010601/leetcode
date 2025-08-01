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
    public bool IsBalanced(TreeNode root) {
        return HeightBalance(root) != -1;
    }
    private int HeightBalance(TreeNode node) {
        if (node == null) {
            return 0;
        }
        // 分別遞迴檢查左右子樹高度
        int leftHeight = HeightBalance(node.left);
        if (leftHeight == -1) {
            return -1;
        }
        int rightHeight = HeightBalance(node.right);
        if (rightHeight == -1) {
            return -1;
        }

        // 左右高度相差超過一即為不符合條件
        if (Math.Abs(leftHeight - rightHeight) > 1) {
            return -1;
        }
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}