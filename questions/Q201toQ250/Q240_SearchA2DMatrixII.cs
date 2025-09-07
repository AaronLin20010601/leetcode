public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int row = matrix.Length, col = matrix[0].Length;
        int rowIndex = 0, colIndex = col - 1;

        // 逐行排查檢查數值
        while (rowIndex < row && colIndex >= 0) {
            int current = matrix[rowIndex][colIndex];
            if (current == target) {
                return true;
            }

            // 數值過大,往前一欄移動
            if (current > target) {
                colIndex--;
            }
            // 數值過小,往下一列移動
            else {
                rowIndex++;
            }
        }
        return false;
    }
}