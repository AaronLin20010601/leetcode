public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        List<int> result = new List<int>();
        if (matrix.Length == 0) return result;

        // 上下左右的當前邊界
        int top = 0, bottom = matrix.Length - 1;
        int left = 0, right = matrix[0].Length - 1;
        // 邊界收斂前持續內繞
        while (top <= bottom && left <= right) {
            // 向右繞行
            for (int col = left; col <= right; col++) {
                result.Add(matrix[top][col]);
            }
            top++;

            // 向下繞行
            for (int row = top; row <= bottom; row++) {
                result.Add(matrix[row][right]);
            }
            right--;

            // 向左繞行
            if (top <= bottom) {
                for (int col = right; col >= left; col--) {
                    result.Add(matrix[bottom][col]);
                }
                bottom--;
            }

            // 向上繞行
            if (left <= right) {
                for (int row = bottom; row >= top; row--) {
                    result.Add(matrix[row][left]);
                }
                left++;
            }
        }
        return result;
    }
}