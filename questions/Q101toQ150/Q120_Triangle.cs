public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        // 使用 dynamic programming 進行檢查
        int pathLength = triangle.Count;
        int[] dp = new int[pathLength];

        // 初始化最底層
        for (int i = 0; i < pathLength; i++) {
            dp[i] = triangle[pathLength - 1][i];
        }
        // 從倒數第二層開始往上檢查總和
        for (int i = pathLength - 2; i >= 0; i--) {
            for (int j = 0; j <= i; j++) {
                dp[j] = triangle[i][j] + Math.Min(dp[j], dp[j + 1]);
            }
        }
        return dp[0];
    }
}