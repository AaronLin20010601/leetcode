public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        // 對目標數字進行二分搜尋
        while (left <= right) {
            int mid = left + (right - left) / 2;
            // 找到目標數字
            if (nums[mid] == target) {
                return mid;
            }
            // 向右尋找
            else if (nums[mid] < target) {
                left = mid + 1;
            }
            // 向左尋找
            else {
                right = mid - 1;
            }
        }
        return left;
    }
}