public class Solution {
    public int TrailingZeroes(int n) {
        int count = 0;

        // 計算 5 的數量,即為乘積後 0 的數量
        while (n > 0) {
            n /= 5;
            count += n;
        }
        return count;
    }
}