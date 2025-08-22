public class Solution {
    public int CountPrimes(int n) {
        if (n <= 2) {
            return 0;
        }
        // 只檢查奇數
        int oddSize = n / 2;
        bool[] isPrime = new bool[oddSize];
        Array.Fill(isPrime, true);

        for (int i = 1; 2 * i + 1 <= (int)Math.Sqrt(n); i++) {
            if (isPrime[i]) {
                // 將該質數的倍數從質數中移除
                int primeNum = 2 * i + 1;
                int index = (primeNum * primeNum - 1) / 2;
                for (int j = index; j < oddSize; j += primeNum) {
                    isPrime[j] = false;
                }
            }
        }

        // 2 也為一個質數
        int count = 1;
        for (int i = 1; i < oddSize; i++) {
            if (isPrime[i]) {
                count++;
            }
        }
        return count;
    }
}