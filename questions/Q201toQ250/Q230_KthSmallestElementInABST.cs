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
    private int count = 0;
    private int result = 0;

    public int KthSmallest(TreeNode root, int k) {
        InOrder(root, k);
        return result;
    }
    // 中序歷遍搜尋數字
    private void InOrder(TreeNode node, int k) {
        if (node == null) {
            return;
        }

        // 搜尋左子樹
        InOrder(node.left, k);
        // 檢查當前數字
        count++;
        if (count == k) {
            result = node.val;
            return;
        }
        //搜尋右子樹
        InOrder(node.right, k);
    }
}