public class Solution {
    public int Trap(int[] height) {
        // 使用左右最高邊界進行計算
        int length = height.Length;
        int[] leftMax = new int[length];
        int[] rightMax = new int[length];

        // 取得各位置最高左邊界
        leftMax[0] = height[0];
        for (int i = 1; i < length; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }
        // 取得各位置最高右邊界
        rightMax[length - 1] = height[length - 1];
        for (int i = length - 2; i >= 0; i--) {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }
        // 計算水量
        int water = 0;
        for (int i = 0; i < length; i++) {
            water += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }
        return water;
    }
}