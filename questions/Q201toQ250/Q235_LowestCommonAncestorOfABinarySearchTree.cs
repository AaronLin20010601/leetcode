/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode node = root;
        while (node != null) {
            // 當前節點過大,往左子樹前進
            if (p.val < node.val && q.val < node.val) {
                node = node.left;
            }
            // 當前節點過小,往右子樹前進
            else if (p.val > node.val && q.val > node.val) {
                node = node.right;
            }
            // 當前節點大於等於左節點且小於右節點
            else {
                return node;
            }
        }
        return null;
    }
}