public class Solution {
    public int NumTrees(int n) {
        // 使用 dynamic programming 進行組合計算
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (int node = 2; node <= n; node++) {
            for (int root = 1; root <= node; root++) {
                // 計算左右子樹節點組合
                int left = root - 1, right = node - root;
                dp[node] += dp[left] * dp[right];
            }
        }
        return dp[n];
    }
}