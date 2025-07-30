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
    public IList<TreeNode> GenerateTrees(int n) {
        return BuildTrees(1, n);
    }
    private List<TreeNode> BuildTrees(int first, int last) {
        List<TreeNode> trees = new List<TreeNode>();
        // 加入空節點
        if (first > last) {
            trees.Add(null);
            return trees;
        }

        // 每個數字皆可做為根進行左右分支樹製造
        for (int i = first; i <= last; i++) {
            // 遞迴建立所有可能的左樹和右樹
            List<TreeNode> leftTrees = BuildTrees(first, i - 1);
            List<TreeNode> rightTrees = BuildTrees(i + 1, last);

            foreach (var left in leftTrees) {
                foreach (var right in rightTrees) {
                    TreeNode root = new TreeNode(i);
                    root.left = left;
                    root.right = right;
                    trees.Add(root);
                }
            }
        }
        return trees;
    }
}