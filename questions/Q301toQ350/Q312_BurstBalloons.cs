public class Solution {
    public int MaxCoins(int[] nums) {
        int size = nums.Length + 2;

        int[] balloons = new int[size];
        balloons[0] = 1;
        balloons[size - 1] = 1;
        for (int i = 0; i < size - 2; i++) {
            balloons[i + 1] = nums[i];
        }

        int[,] rangeMaxCoin = new int[size, size];
        return MaxCoinsInRange(balloons, rangeMaxCoin, 0, size - 1);
    }
    // 取得特定範圍內的最大可能 coin 值
    private int MaxCoinsInRange(int[] balloons, int[,] rangeMaxCoin, int left, int right) {
        if (left + 1 == right) {
            return 0;
        }
        if (rangeMaxCoin[left, right] != 0) {
            return rangeMaxCoin[left, right];
        }

        int maxCoin = 0;
        // 逐一遞迴檢查每個氣球作為最後一點的 coin 值
        for (int i = left + 1; i < right; i++) {
            int coin = MaxCoinsInRange(balloons, rangeMaxCoin, left, i) 
            + balloons[left] * balloons[i] * balloons[right] 
            + MaxCoinsInRange(balloons, rangeMaxCoin, i, right);
            if (coin > maxCoin) {
                maxCoin = coin;
            }
        }

        rangeMaxCoin[left, right] = maxCoin;
        return maxCoin;
    }
}