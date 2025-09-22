/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var str = new StringBuilder();
        PreorderSerialize(root, str);

        // 移除尾端 , 並回傳字串
        if (str.Length > 0) {
            str.Length--;
        }
        return str.ToString();
    }
    // 使用前序歷遍進行二元樹拆解
    private void PreorderSerialize(TreeNode node, StringBuilder str) {
        if (node == null) {
            str.Append("n,");
            return;
        }

        // 依根左右順序遞迴歷遍
        str.Append(node.val).Append(",");
        PreorderSerialize(node.left, str);
        PreorderSerialize(node.right, str);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (string.IsNullOrEmpty(data)) {
            return null;
        }

        var nodes = new Queue<string>(data.Split(','));
        return PreorderDeserialize(nodes);
    }
    // 使用前序排序進行二元樹還原
    private TreeNode PreorderDeserialize(Queue<string> nodes) {
        if (nodes.Count == 0) {
            return null;
        }

        string val = nodes.Dequeue();
        if (val == "n") {
            return null;
        }

        // 依根左右順序遞迴歷遍
        TreeNode node = new TreeNode(int.Parse(val));
        node.left = PreorderDeserialize(nodes);
        node.right = PreorderDeserialize(nodes);
        return node;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));