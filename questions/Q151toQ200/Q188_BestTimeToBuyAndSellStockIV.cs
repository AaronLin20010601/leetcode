public class Solution {
    public int MaxProfit(int k, int[] prices) {
        int priceLength = prices.Length;
        if (priceLength == 1) {
            return 0;
        }

        // 可購買次數夠大時直接無限制進行買賣
        if (k >= priceLength / 2) {
            int result = 0;
            for (int i = 1; i < priceLength; i++) {
                if (prices[i] > prices[i - 1]) {
                    result += prices[i] - prices[i - 1];
                }
            }
            return result;
        }

        // 使用 dynamic programming 進行買賣紀錄
        int[] buy = new int[k + 1];
        int[] sell = new int[k + 1];

        // 初始化紀錄陣列
        for (int i = 0; i <= k; i++) {
            buy[i] = int.MinValue;
            sell[i] = 0;
        }
        foreach (int price in prices) {
            // 逐一比較買入和賣出差值
            for (int i = 1; i <= k; i++) {
                buy[i] = Math.Max(buy[i], sell[i - 1] - price);
                sell[i] = Math.Max(sell[i], buy[i] + price);
            }
        }
        return sell[k];
    }
}