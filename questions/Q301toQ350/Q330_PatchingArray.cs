public class Solution {
    public int MinPatches(int[] nums, int n) {
        long missingNum = 1;
        int index = 0, patches = 0;

        while (missingNum <= n) {
            // 拓展最大數字範圍
            if (index < nums.Length && nums[index] <= missingNum) {
                missingNum += nums[index];
                index++;
            }
            // 補上缺失數字
            else {
                missingNum += missingNum;
                patches++;
            }
        }
        return patches;
    }
}