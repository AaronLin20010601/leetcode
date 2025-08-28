public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int numLength = nums.Length;
        int left = 0, sum = 0, numbers = int.MaxValue;

        // 使用滑動視窗進行左右範圍移動檢查條件
        for (int right = 0; right < numLength; right++) {
            sum += nums[right];

            while (sum >= target) {
                numbers = Math.Min(numbers, right - left + 1);
                sum -= nums[left];
                left++;
            }
        }
        return numbers == int.MaxValue ? 0 : numbers;
    }
}