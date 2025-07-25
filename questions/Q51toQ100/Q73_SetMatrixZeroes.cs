public class Solution {
    public void SetZeroes(int[][] matrix) {
        int height = matrix.Length, width = matrix[0].Length;

        // 使用第一欄和第一列作為檢查標記
        bool firstRowReset = false, firstColumnReset = false;
        // 檢查第一欄和第一列是否需要歸零
        for (int i = 0; i < height; i++) {
            if (matrix[i][0] == 0) {
                firstRowReset = true;
                break;
            }
        }
        for (int i = 0; i < width; i++) {
            if (matrix[0][i] == 0) {
                firstColumnReset = true;
                break;
            }
        }

        // 檢查除第一欄和第一列外是否有 0 並進行標記
        for (int i = 1; i < height; i++) {
            for (int j = 1; j < width; j++) {
                if (matrix[i][j] == 0) {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }
        
        // 進行除第一欄和第一列外的歸零
        for (int i = 1; i < height; i++) {
            for (int j = 1; j < width ; j++) {
                if (matrix[i][0] == 0 || matrix[0][j] == 0) {
                    matrix[i][j] = 0;
                }
            }
        }
        // 進行第一欄和第一列的歸零
        if (firstRowReset) {
            for (int i = 0; i < height; i++) {
                matrix[i][0] = 0;
            }
        }
        if (firstColumnReset) {
            for (int i = 0; i < width; i++) {
                matrix[0][i] = 0;
            }
        }
    }
}