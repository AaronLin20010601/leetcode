public class Solution {
    public int MaxProfit(int[] prices) {
        int minPrice = int.MaxValue, maximum = 0;

        // 歷遍檢查最小價格和賣出價差
        foreach (int price in prices) {
            if (price < minPrice) {
                minPrice = price;
            }
            else {
                int profit = price - minPrice;
                if (profit > maximum) {
                    maximum = profit;
                }
            }
        }
        return maximum;
    }
}