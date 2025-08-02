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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        var result = new List<IList<int>>();
        var current = new List<int>();
        GetPath(root, targetSum, current, result);
        return result;
    }
    private void GetPath(TreeNode node, int remainingSum, List<int> current, List<IList<int>> result) {
        if (node == null) {
            return;
        }

        // 將當前節點值加入儲存列表
        current.Add(node.val);
        remainingSum -= node.val;

        // 找到葉節點且符合加總值
        if (node.left == null && node.right == null && remainingSum == 0) {
            result.Add(new List<int>(current));
        }
        // 遞迴檢查左右子樹路徑
        else {
            GetPath(node.left, remainingSum, current, result);
            GetPath(node.right, remainingSum, current, result);
        }
        // 回溯至上一層
        current.RemoveAt(current.Count - 1);
    }
}