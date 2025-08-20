public class Solution {
    public int HammingWeight(int n) {
        int count = 0;
        // 數值除以 2 有餘 1 代表二進位中有位元值為 1
        while (n > 0) {
            if (n % 2 == 1) {
                count++;
            }
            n /= 2;
        }
        return count;
    }
}