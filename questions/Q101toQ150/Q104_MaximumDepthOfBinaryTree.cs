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
    public int MaxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        // 分別尋找左右子樹的最大深度節點
        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);
        return 1 + Math.Max(leftDepth, rightDepth);
    }
}