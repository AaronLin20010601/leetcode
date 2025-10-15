public class Solution {
    private int rows, cols;
    private int[,] longestPath;
    private int[][] grid;
    private int[][] directions = new int[][] {
        new int[] { 1, 0 },
        new int[] { 0, 1 },
        new int[] { -1, 0 },
        new int[] { 0, -1 }
    };
    public int LongestIncreasingPath(int[][] matrix) {
        grid = matrix;
        rows = matrix.Length;
        cols = matrix[0].Length;
        longestPath = new int[rows, cols];
        int maxLength = 0;

        // 歷遍每一格當作起點的可能
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                int pathLength = GetLongestPath(i, j);
                maxLength = Math.Max(pathLength, maxLength);
            }
        }
        return maxLength;
    }
    // 計算當前起點格可能的最大路徑長度
    private int GetLongestPath(int rowIndex, int colIndex) {
        if (longestPath[rowIndex, colIndex] != 0) {
            return longestPath[rowIndex, colIndex];
        }

        int currentNum = grid[rowIndex][colIndex];
        int currentMaxLength = 1;

        // 檢查往四個方向移動的條件
        foreach (var direction in directions) {
            int nextRow = rowIndex + direction[0];
            int nextCol = colIndex + direction[1];

            if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols) {
                continue;
            }
            // 符合條件則遞迴檢查下一位置
            if (grid[nextRow][nextCol] > currentNum) {
                currentMaxLength = Math.Max(currentMaxLength, 1 + GetLongestPath(nextRow, nextCol));
            }
        }
        longestPath[rowIndex, colIndex] = currentMaxLength;
        return currentMaxLength;
    }
}