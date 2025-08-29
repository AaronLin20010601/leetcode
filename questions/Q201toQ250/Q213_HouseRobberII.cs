public class Solution {
    public int Rob(int[] nums) {
        int house = nums.Length;
        if (house == 1) {
            return nums[0];
        }

        // 頭尾不可同時被選取
        return Math.Max(RobLinear(nums, 0, house - 2), RobLinear(nums, 1, house - 1));
    }
    // 僅取直線範圍的選取
    private int RobLinear(int[] nums, int start, int end) {
        if (start == end) {
            return nums[start];
        }

        // 使用 dynamic programming 進行紀錄
        int[] dp = new int[end - start + 1];
        dp[0] = nums[start];
        dp[1] = Math.Max(nums[start], nums[start + 1]);

        for (int i = 2; i < dp.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[start + i]);
        }
        return dp[dp.Length - 1];
    }
}