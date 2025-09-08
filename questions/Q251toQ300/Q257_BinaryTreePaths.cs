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
    public IList<string> BinaryTreePaths(TreeNode root) {
        var result = new List<string>();
        if (root == null) {
            return result;
        }

        FindPath(root, root.val.ToString(), result);
        return result;
    }
    // 取得節點路徑
    private void FindPath(TreeNode node, string path, List<string> result) {
        // 已到達尾端
        if (node.left == null && node.right == null) {
            result.Add(path);
            return;
        }
        // 往左右子樹遞迴檢查路徑
        if (node.left != null) {
            FindPath(node.left, path + "->" + node.left.val, result);
        }
        if (node.right != null) {
            FindPath(node.right, path + "->" + node.right.val, result);
        }
    }
}