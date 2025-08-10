public class Solution {
    public int SingleNumber(int[] nums) {
        int target = 0;
        for (int i = 0; i < nums.Length; i++){
            // 使用 XOR 運算篩選,成對出現的數字會抵消
            target ^= nums[i];
        }
        return target;
    }
}