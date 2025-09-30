public class Solution {
    public int MaxProfit(int[] prices) {
        int stocks = prices.Length;
        int hold = -prices[0], sell = 0, cooldown = 0;

        // 逐一檢查買賣和冷卻狀態變化
        for (int i = 1; i < stocks; i++) {
            int price = prices[i];
            int lastHold = hold, lastSell = sell, lastCooldown = cooldown;

            // 計算當前最大利潤值
            hold = Math.Max(lastHold, lastCooldown - price);
            sell = lastHold + price;
            cooldown = Math.Max(lastSell, lastCooldown);
        }
        return Math.Max(sell, cooldown);
    }
}