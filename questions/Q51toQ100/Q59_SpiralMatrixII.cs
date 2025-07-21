public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++) {
            matrix[i] = new int[n];
        }

        // 上下左右的當前邊界
        int top = 0, bottom = n - 1;
        int left = 0, right = n - 1;
        int num = 1, maximum = n * n;
        // 進行繞行填空
        while (num <= maximum) {
            // 向右繞行
            for (int i = left; i <= right && num <= maximum; i++) {
                matrix[top][i] = num++;
            }
            top++;

            // 向下繞行
            for (int i = top; i <= bottom && num <= maximum; i++) {
                matrix[i][right] = num++;
            }
            right--;

            // 向左繞行
            for (int i = right; i >= left && num <= maximum; i--) {
                matrix[bottom][i] = num++;
            }
            bottom--;

            // 向上繞行
            for (int i = bottom; i >= top && num <= maximum; i--) {
                matrix[i][left] = num++;
            }
            left++;
        }
        return matrix;
    }
}