public class Solution {
    public int FindPeakElement(int[] nums) {
        if (nums.Length == 1) {
            return 0;
        }

        // 檢查最左和最右端
        if (nums[0] > nums[1]) {
            return 0;
        }
        if (nums[nums.Length - 1] > nums[nums.Length - 2]) {
            return nums.Length - 1;
        }

        int left = 1, right = nums.Length - 2;
        // 從左右兩端收斂檢查
        while (left <= right) {
            if (nums[left] > nums[left - 1] && nums[left] > nums[left + 1]) {
                return left;
            }
            if (nums[right] > nums[right - 1] && nums[right] > nums[right + 1]) {
                return right;
            }
            left++;
            right--;
        }
        return 0;
    }
}