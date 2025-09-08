public class Solution {
    public int NthUglyNumber(int n) {
        if (n == 1) {
            return 1;
        }

        int[] ugly = new int[n];
        ugly[0] = 1;
        int index2 = 0, index3 = 0, index5 = 0;
        int next2 = 2, next3 = 3, next5 = 5;

        // 逐個計算可能的最小乘積組合
        for (int i = 1; i < n; i++) {
            int nextUgly = Math.Min(next2, Math.Min(next3, next5));
            ugly[i] = nextUgly;

            // 推進可乘最小數值
            if (nextUgly == next2) {
                index2++;
                next2 = ugly[index2] * 2;
            }
            if (nextUgly == next3) {
                index3++;
                next3 = ugly[index3] * 3;
            }
            if (nextUgly == next5) {
                index5++;
                next5 = ugly[index5] * 5;
            }
        }
        return ugly[n - 1];
    }
}