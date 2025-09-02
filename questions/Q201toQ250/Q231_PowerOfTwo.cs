public class Solution {
    public bool IsPowerOfTwo(int n) {
        // 正整數和 number and number - 1 運算後為 0 的值為 2 的倍數
        return n > 0 && (n & (n - 1)) == 0;
    }
}