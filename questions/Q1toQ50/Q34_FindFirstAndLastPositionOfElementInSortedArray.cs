public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int left = FindLeft(nums, target);
        int right = FindRight(nums, target);
        return new int[] { left, right };
    }
    // 尋找左側邊界
    private int FindLeft(int[] nums, int target) {
        int left = 0, right = nums.Length - 1, index = -1;

        // 對目標數字進行二分搜尋
        while (left <= right) {
            int mid = left + (right - left) / 2;
            // 向左尋找
            if (nums[mid] == target) {
                index = mid;
                right = mid - 1;
            }
            else if (nums[mid] < target) {
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }
        return index;
    }
    // 尋找右側邊界
    private int FindRight(int[] nums, int target) {
        int left = 0, right = nums.Length - 1, index = -1;

        // 對目標數字進行二分搜尋
        while (left <= right) {
            int mid = left + (right - left) / 2;
            // 向右尋找
            if (nums[mid] == target) {
                index = mid;
                left = mid + 1;
            }
            else if (nums[mid] < target) {
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }
        return index;
    }
}