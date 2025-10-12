public class Solution {
    public bool IsPowerOfThree(int n) {
        // 排除負數
        if (n < 1) {
            return false;
        }

        // 檢查是否為三的倍數
        while (n > 1) {
            if (n % 3 == 0) {
                n /= 3;
            }
            else {
                return false;
            }
        }
        return true;
    }
}