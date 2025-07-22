public class Solution {
    public int MinPathSum(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;

        // 只往左和只往下為一種路徑
        for (int i = 1; i < m; i++) {
            grid[i][0] += grid[i - 1][0];
        }
        for (int i = 1; i < n; i++) {
            grid[0][i] += grid[0][i - 1];
        }

        // 取得可能的最小加總值
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
            }
        }
        return grid[m - 1][n - 1];
    }
}