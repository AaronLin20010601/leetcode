public class Solution {
    public int RemoveDuplicates(int[] nums) {
        // 至少保留兩數字
        if (nums.Length <= 2) {
            return nums.Length;
        }
        int index = 2;

        for (int i = 2; i < nums.Length; i++) {
            // 檢查為不同數字並移動位置
            if (nums[i] != nums[index - 2]) {
                nums[index] = nums[i];
                index++;
            }
        }
        return index;
    }
}