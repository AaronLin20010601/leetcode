public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        int row = dungeon.Length, col = dungeon[0].Length;

        // 使用 dynamic programming 反向推導紀錄可能最小生命值
        int[,] dp = new int[row + 1, col + 1];
        for (int i = 0; i <= row; i++) {
            for (int j = 0; j <= col; j++) {
                dp[i, j] = int.MaxValue;
            }
        }

        dp[row, col - 1] = 1;
        dp[row - 1, col] = 1;
        // 進行紀錄比較
        for (int i = row - 1; i >= 0; i--) {
            for (int j = col - 1; j >= 0; j--) {
                int health = Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i][j];
                dp[i, j] = Math.Max(1, health);
            }
        }
        return dp[0, 0];
    }
}