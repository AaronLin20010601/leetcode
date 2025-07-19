public class Solution {
    public int Search(int[] nums, int target) {
        // 使用左右端點收斂尋找目標
        int left = 0, right = nums.Length - 1;
        while (left <= right) {
            if (nums[left] == target) {
                return left;
            }
            if (nums[right] == target) {
                return right;
            }
            left++;
            right--;
        }
        return -1;
    }
}