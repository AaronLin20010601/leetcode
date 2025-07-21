public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = nums[0], sum = nums[0];
        // 歷遍陣列進行計算尋找
        for (int i = 1; i < nums.Length; i++) {
            sum = Math.Max(nums[i], sum + nums[i]);
            max = Math.Max(max, sum);
        }
        return max;
    }
}