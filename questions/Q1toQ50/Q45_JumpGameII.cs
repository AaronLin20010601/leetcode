public class Solution {
    public int Jump(int[] nums) {
        int jumps = 0, currentBound = 0, farthest = 0;
        for (int i = 0; i < nums.Length - 1; i++) {
            // 當前最大可到達範圍
            farthest = Math.Max(farthest, i + nums[i]);
            // 達到當前最遠邊界時則進入下一步
            if (i == currentBound) {
                jumps++;
                currentBound = farthest;
                // 已可達到終點
                if (currentBound >= nums.Length - 1) {
                    break;
                }
            }
        }
        return jumps;
    }
}