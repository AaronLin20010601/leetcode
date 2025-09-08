public class Solution {
    public bool IsUgly(int n) {
        // 必定為 2, 3, 5 其中一者的質因數或沒有因數
        if (n >= 1 && n <= 6) {
            return true;
        }
        // 數值為負數或零
        if (n < 1) {
            return false;
        }

        // 將數字縮減至找到非條件質數或符合條件
        while (n > 6) {
            if (n % 2 == 0) {
                n /= 2;
            }
            else if (n % 3 == 0) {
                n /= 3;
            }
            else if (n % 5 == 0) {
                n /= 5;
            }
            else {
                return false;
            }
        }
        return true;
    }
}