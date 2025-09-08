public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;
        int expectSum = n * (n + 1) / 2;

        // 計算總和差值
        int sum = 0;
        for (int i = 0; i < n; i++) {
            sum += nums[i];
        }
        return expectSum - sum;
    }
}