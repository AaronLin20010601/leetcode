public class Solution {
    public int Rob(int[] nums) {
        int house = nums.Length;
        if (house == 1) {
            return nums[0];
        }

        // 使用 dynamic programming 進行紀錄
        int[] dp = new int[house];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < house; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }
        return dp[house - 1];
    }
}