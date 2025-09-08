public class Solution {
    public int AddDigits(int num) {
        // 數值超過個位數則繼續計算
        while (num > 9) {
            int current = num;
            int sum = 0;

            // 將各位數字相加
            while (current != 0) {
                sum += current % 10;
                current /= 10;
            }
            num = sum;
        }
        return num;
    }
}