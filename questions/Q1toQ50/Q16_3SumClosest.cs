public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        // 排序為由小到大
        Array.Sort(nums);
        int result = nums[0] + nums[1] + nums[2];

        for (int i = 0; i < nums.Length - 2; i++) {
            // 從兩側收斂檢查
            int left = i + 1, right = nums.Length - 1;
            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];

                // 檢查差值
                if (Math.Abs(sum - target) < Math.Abs(result - target)) {
                    result = sum;
                }
                
                // 相加結果過小則左端向中移動
                if (sum < target) {
                    left++;
                }
                // 相加結果過大則右端向中移動
                else {
                    right--;
                }
            }
        }
        return result;
    }
}