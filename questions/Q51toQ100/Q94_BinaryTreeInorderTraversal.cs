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
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        solve(root, result);
        return result;
    }
    // 依據左中右節點遞迴的順序將值紀錄
    private void solve(TreeNode root, List<int> result) {
        if (root == null) {
            return;
        }
        solve(root.left, result);
        result.Add(root.val);
        solve(root.right, result);
    }
}