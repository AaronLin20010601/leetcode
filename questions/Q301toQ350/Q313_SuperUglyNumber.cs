public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes) {
        if (n == 1) {
            return 1;
        }

        int size = primes.Length;
        int[] ugly = new int[n];
        ugly[0] = 1;

        // 紀錄當前質數使用次數
        int[] primeIndex = new int[size];
        // 紀錄當前最小 ugly 值
        long[] currentUgly = new long[size];
        for (int i = 0; i < size; i++) {
            currentUgly[i] = primes[i];
        }

        for (int i = 1; i < n; i++) {
            // 找出當前最小 ugly 值
            long nextUgly = currentUgly[0];
            for (int j = 1; j < size; j++) {
                if (currentUgly[j] < nextUgly) {
                    nextUgly = currentUgly[j];
                }
            }
            ugly[i] = (int)nextUgly;

            // 更新各質數使用次數
            for (int j = 0; j < size; j++) {
                if (currentUgly[j] == nextUgly) {
                    primeIndex[j]++;
                    currentUgly[j] = (long)ugly[primeIndex[j]] * primes[j];
                }
            }
        }
        return ugly[n - 1];
    }
}