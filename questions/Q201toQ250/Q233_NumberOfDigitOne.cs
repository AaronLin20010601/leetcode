public class Solution {
    public int CountDigitOne(int n) {
        long number = n, factor = 1, count = 0;

        while (factor <= number) {
            // 依照位數進行檢查
            long right = number % factor;
            long current = (number / factor) % 10;
            long left = number / (factor * 10);

            // 僅當前位數的更高位數存在 1
            if (current == 0) {
                count += left * factor;
            }
            // 當前位數存在等量的 1 和更高位數存在相對應的 1
            else if (current == 1) {
                count += left * factor + (right + 1);
            }
            // 當前位數存在完整循環的 1
            else {
                count += (left + 1) * factor;
            }
            factor *= 10;
        }
        return (int)count;
    }
}