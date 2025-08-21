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
    public IList<int> RightSideView(TreeNode root) {
        var result = new List<int>();
        if (root == null) {
            return result;
        }

        // 第一層節點
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        // 使用 levelorder traversal 並只取最後一節點
        while (queue.Count > 0) {
            int currentLevelSize = queue.Count;
            TreeNode lastNode = null;
            // 歷遍當前層節點
            for (int i = 0; i < currentLevelSize; i++) {
                var node = queue.Dequeue();
                lastNode = node;

                // 將尚有的左右節點加入進行下一輪歷遍
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            result.Add(lastNode.val);
        }
        return result;
    }
}