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
    private TreeNode firstWrong = null;
    private TreeNode secondWrong = null;
    private TreeNode previous = new TreeNode(int.MinValue);

    public void RecoverTree(TreeNode root) {
        InorderTraversal(root);
        int temp = firstWrong.val;
        firstWrong.val = secondWrong.val;
        secondWrong.val = temp;
    }
    // 使用中序歷遍節點進行檢查
    private void InorderTraversal(TreeNode node) {
        if (node == null) {
            return;
        }
        InorderTraversal(node.left);

        // 出現排序錯誤(中序歷遍順序為左中右節點,節點值大小為左<中<右)
        if (previous.val > node.val) {
            // 找出第一個出錯節點
            if (firstWrong == null) {
                firstWrong = previous;
            }
            // 找出第二個出錯節點
            secondWrong = node;
        }

        previous = node;
        InorderTraversal(node.right);
    }
}