public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int row = 0, col = matrix[0].Length - 1;

        // 從右上角進行收斂檢查
        while (row < matrix.Length && col >= 0) {
            if (matrix[row][col] == target) {
                return true;
            }
            else if (matrix[row][col] < target) {
                row++;
            }
            else {
                col--;
            }
        }
        return false;
    }
}