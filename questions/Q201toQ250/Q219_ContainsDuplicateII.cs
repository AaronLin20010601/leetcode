public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var window = new HashSet<int>();

        // 使用滑動視窗對範圍內數字進行檢查
        for (int i = 0; i < nums.Length; i++) {
            if (window.Contains(nums[i])) {
                return true;
            }

            window.Add(nums[i]);
            if (window.Count > k) {
                window.Remove(nums[i - k]);
            }
        }
        return false;
    }
}