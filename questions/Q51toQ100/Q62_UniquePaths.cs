public class Solution {
    public int UniquePaths(int m, int n) {
        // 使用 dynamic programming 紀錄可能路徑數
        int[,] dp = new int[m, n];

        // 只往左和只往下為一種路徑
        for (int i = 0; i < m; i++) {
            dp[i, 0] = 1;
        }
        for (int i = 0; i < n; i++) {
            dp[0, i] = 1;
        }

        // 其他格的路徑來源為上方和左方格的路徑可能相加
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }
        return dp[m - 1, n - 1];
    }
}