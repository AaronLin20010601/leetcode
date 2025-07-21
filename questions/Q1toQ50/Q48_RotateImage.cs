public class Solution {
    public void Rotate(int[][] matrix) {
        int length = matrix.Length;
        // 將行列進行互換
        for (int i = 0; i < length; i++) {
            for (int j = i + 1; j < length; j++) {
                Swap(ref matrix[i][j], ref matrix[j][i]);
            }
        }

        // 將新的列反轉
        for (int i = 0; i < length; i++) {
            int left = 0, right = length - 1;
            while (left < right) {
                Swap(ref matrix[i][left], ref matrix[i][right]);
                left++;
                right--;
            }
        }
    }
    // 數字互換
    private void Swap(ref int a, ref int b) {
        int temp = a;
        a = b;
        b = temp;
    }
}