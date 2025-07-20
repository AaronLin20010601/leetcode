public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int length = nums.Length;
        // 將數字交換至正確位置
        for (int i = 0; i < length; i++) {
            while (nums[i] > 0 && nums[i] <= length && nums[nums[i] - 1] != nums[i]) {
                int newIndex = nums[i] - 1;
                int original = nums[i];
                nums[i] = nums[newIndex];
                nums[newIndex] = original;
            }
        }

        // 找出不符合應有數字的位置
        for (int i = 0; i < length; i++) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }
        return length + 1;
    }
}