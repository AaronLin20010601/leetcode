public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        int[,] dp = new int[rows + 1, cols + 1];
        int maxSide = 0;

        // 使用 dynamic programming 紀錄當前最大邊長
        for (int i = 1; i <= rows; i++) {
            for (int j = 1; j <= cols; j++) {
                // 數字為 1 則更新最大邊長
                if (matrix[i - 1][j - 1] == '1') {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                    if (dp[i, j] > maxSide) {
                        maxSide = dp[i, j];
                    }
                }
                else {
                    dp[i, j] = 0;
                }
            }
        }
        return maxSide * maxSide;
    }
}