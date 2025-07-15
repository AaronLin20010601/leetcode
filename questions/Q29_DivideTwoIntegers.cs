public class Solution {
    public int Divide(int dividend, int divisor) {
        // 處理邊界情況
        if (dividend == int.MinValue && divisor == -1) {
            return int.MaxValue;
        }
        return (int)((long)dividend / divisor);
    }
}