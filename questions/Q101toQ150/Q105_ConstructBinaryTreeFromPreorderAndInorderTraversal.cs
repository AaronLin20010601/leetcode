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
    private Dictionary<int, int> inorderIndexMap;

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // 用於尋找中序根元素
        inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            inorderIndexMap[inorder[i]] = i;
        }

        return Build(preorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
    }
    // 依據前序和中序陣列建立樹
    private TreeNode Build(int[] preorder, int preorderStart, int preorderEnd, int inorderStart, int inorderEnd) {
        if (preorderStart > preorderEnd || inorderStart > inorderEnd) {
            return null;
        }

        // 前序歷遍組的首個值即為該樹或子樹的根
        int rootValue = preorder[preorderStart];
        TreeNode root = new TreeNode(rootValue);
        // 取得根在中序歷遍的位置
        int rootIndex = inorderIndexMap[rootValue];
        int leftTreeSize = rootIndex - inorderStart;

        // 遞迴分別建立左子樹和右子樹
        root.left = Build(preorder, preorderStart + 1, preorderStart + leftTreeSize, inorderStart, rootIndex - 1);
        root.right = Build(preorder, preorderStart + 1 + leftTreeSize, preorderEnd, rootIndex + 1, inorderEnd);
        return root;
    }
}