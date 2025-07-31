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

    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        // 用於尋找中序根元素
        inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            inorderIndexMap[inorder[i]] = i;
        }

        return Build(postorder, 0, postorder.Length - 1, 0, inorder.Length - 1);
    }
    // 依據中序和後序陣列建立樹
    private TreeNode Build(int[] postorder, int postorderStart, int postorderEnd, int inorderStart, int inorderEnd) {
        if (postorderStart > postorderEnd || inorderStart > inorderEnd) {
            return null;
        }

        // 後序歷遍組的最後一個值即為該樹或子樹的根
        int rootValue = postorder[postorderEnd];
        TreeNode root = new TreeNode(rootValue);
        // 取得根在中序歷遍的位置
        int rootIndex = inorderIndexMap[rootValue];
        int rightTreeSize = inorderEnd - rootIndex;

        // 遞迴分別建立右子樹和左子樹
        root.right = Build(postorder, postorderEnd - rightTreeSize, postorderEnd - 1, rootIndex + 1, inorderEnd);
        root.left = Build(postorder, postorderStart, postorderEnd - rightTreeSize - 1, inorderStart, rootIndex - 1);
        return root;
    }
}