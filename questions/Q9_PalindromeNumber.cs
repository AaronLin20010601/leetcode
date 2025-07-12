public class Solution {
    public bool IsPalindrome(int x) {
        // 排除尾數為零或負數
        if (x < 0 || (x % 10 == 0 && x != 0)) {
            return false;
        }

        // 產生對稱數字
        int reverse = 0;
        while (x > reverse) {
            reverse = reverse * 10 + x % 10;
            x /= 10;
        }
        return x == reverse || x == reverse / 10;
    }
}