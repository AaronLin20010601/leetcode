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
public class BSTIterator {
    // 使用 queue 記錄節點
    private Queue<int> queue;

    // 使用中序歷遍節點
    private void Inorder(TreeNode root) {
        if (root == null) return;
        Inorder(root.left);
        queue.Enqueue(root.val);
        Inorder(root.right);
    }

    public BSTIterator(TreeNode root) {
        queue = new Queue<int>();
        Inorder(root);
    }
    
    public int Next() {
        return queue.Dequeue();
    }
    
    public bool HasNext() {
        return queue.Count > 0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */