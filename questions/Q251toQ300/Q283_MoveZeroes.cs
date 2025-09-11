public class Solution {
    public void MoveZeroes(int[] nums) {
        int index = 0;

        // 將不為 0 的數字前移
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                nums[index] = nums[i];
                index++;
            }
        }
        // 補上對應數量的 0
        while (index < nums.Length) {
            nums[index] = 0;
            index++;
        }
    }
}