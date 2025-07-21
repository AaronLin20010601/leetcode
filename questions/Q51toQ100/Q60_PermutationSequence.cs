public class Solution {
    public string GetPermutation(int n, int k) {
        // 加入所有可用數字
        List<int> numbers = new List<int>();
        for (int i = 1; i <= n; i++) {
            numbers.Add(i);
        }
        // 計算乘階以分割搜尋排列範圍
        int[] factorial = new int[n + 1];
        factorial[0] = 1;
        for (int i = 1; i <= n; i++) {
            factorial[i] = factorial[i - 1] * i;
        }
        k--;

        StringBuilder result = new StringBuilder();
        // 使用乘階範圍收斂逐步取得結果
        for (int i = 1; i <= n; i++) {
            // 根據乘階區塊加入數字
            int blockSize = factorial[n - i];
            int index = k / blockSize;

            result.Append(numbers[index]);
            numbers.RemoveAt(index);
            k %= blockSize;
        }
        return result.ToString();
    }
}