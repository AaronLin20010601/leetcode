public class Solution {
    public int LengthOfLIS(int[] nums) {
        int numbers = nums.Length;
        int[] dp = new int[numbers];
        int longest = 1;

        // 歷遍每個數字和其後面的數字
        for (int i = 0; i < numbers; i++) {
            dp[i] = 1;

            for (int j = 0; j < i; j++) {
                // 後者數字較小,進行遞增數量結算
                if (nums[j] < nums[i]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            longest = Math.Max(longest, dp[i]);
        }
        return longest;
    }
}