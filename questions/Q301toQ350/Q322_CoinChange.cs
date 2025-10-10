public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) {
            return 0;
        }

        // 使用 dynamic programming 進行可能結果查找
        int[] dp = new int[amount + 1];
        for (int i = 1; i <= amount; i++) {
            dp[i] = amount + 1;
        }
        dp[0] = 0;

        // 歷遍並檢查所有數量和 coin 類型
        for (int i = 1; i <= amount; i++) {
            foreach (var coin in coins) {
                if (coin <= i) {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }
        return dp[amount] > amount ? -1 : dp[amount];
    }
}