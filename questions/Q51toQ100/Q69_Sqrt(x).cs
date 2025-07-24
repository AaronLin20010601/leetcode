public class Solution {
    public int MySqrt(int x) {
        if (x == 0 || x == 1) {
            return x;
        }

        // 使用二分搜尋法進行查找
        int left = 1, right = x / 2, result = 0;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            long square = (long)mid * mid;

            // 乘積相同即找到數字
            if (square == x) {
                return mid;
            }
            // 乘積過小,左邊界右移
            else if (square < x) {
                result = mid;
                left = mid + 1;
            }
            // 乘積過大,右邊界左移
            else {
                right = mid - 1;
            }
        }
        return result;
    }
}