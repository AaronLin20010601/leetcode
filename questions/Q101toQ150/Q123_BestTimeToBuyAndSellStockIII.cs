public class Solution {
    public int MaxProfit(int[] prices) {
        // 總共兩次買入和賣出
        int buy1 = int.MinValue, buy2 = int.MinValue;
        int sell1 = 0, sell2 = 0;

        // 歷遍檢查最小價格和賣出價差
        foreach (int price in prices) {
            buy1 = Math.Max(buy1, -price);
            sell1 = Math.Max(sell1, buy1 + price);
            buy2 = Math.Max(buy2, sell1 - price);
            sell2 = Math.Max(sell2, buy2 + price);
        }
        return sell2;
    }
}