public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length == 0) return 0;

        int unique = 0;
        for (int i = 1; i < nums.Length; i++) {
            // 檢查為不同數字並移動位置
            if (nums[i] != nums[unique]) {
                unique++;
                nums[unique] = nums[i];
            }
        }
        return unique + 1;
    }
}