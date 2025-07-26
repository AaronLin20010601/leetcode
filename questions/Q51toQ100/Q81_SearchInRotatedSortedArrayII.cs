public class Solution {
    public bool Search(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        // 從左右兩側收斂檢查
        while (left <= right) {
            if (nums[left] == target || nums[right] == target) {
                return true;
            }
            left++;
            right--;
        }
        return false;
    }
}