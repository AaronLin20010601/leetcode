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
    public bool IsSymmetric(TreeNode root) {
        if (root == null) {
            return false;
        }
        return Check(root.left, root.right);
    }
    // 檢查節點對稱性
    private bool Check(TreeNode left, TreeNode right) {
        if (left == null && right == null) {
            return true;
        }
        // 僅一邊為空節點則不對稱
        if (left == null || right == null) {
            return false;
        }
        // 遞迴檢查鏡像節點
        return (left.val == right.val) && Check(left.left, right.right) && Check(left.right, right.left);
    }
}