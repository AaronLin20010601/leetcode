public class Solution {
    public bool CanJump(int[] nums) {
        int farthest = 0;
        for (int i = 0; i < nums.Length; i++) {
            // 已無法抵達終點
            if (i > farthest) {
                return false;
            }
            // 當前最大可到達範圍
            farthest = Math.Max(farthest, i + nums[i]);
            // 可抵達終點
            if (farthest >= nums.Length - 1) {
                return true;
            }
        }
        return true;
    }
}