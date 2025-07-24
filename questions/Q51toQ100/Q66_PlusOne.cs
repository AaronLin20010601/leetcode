public class Solution {
    public int[] PlusOne(int[] digits) {
        // 從最後一位數字開始
        for (int i = digits.Length - 1; i >= 0; i--) {
            // 加一後不進位
            if (digits[i] < 9) {
                digits[i]++;
                return digits;
            }
            digits[i] = 0;
        }
        // 進位至最後一數字
        int[] result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}