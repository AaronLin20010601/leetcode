public class Solution {
    public void NextPermutation(int[] nums) {
        int length = nums.Length;

        // 由右往左直到找到 nums[i] < nums[i + 1] 的位置
        int index = -1;
        for (int i = length - 2; i >= 0; i--) {
            if (nums[i] < nums[i + 1]) {
                index = i;
                break;
            }
        }

        // 如果有找到條件值,由右往左找直到找到首個比 nums[index] 大的數字
        if (index != -1) {
            for (int i = length - 1; i > index; i--) {
                if (nums[i] > nums[index]) {
                    Swap(nums, index, i);
                    break;
                }
            }
        }
        // 反轉 index 以右的陣列區間以達成升序
        Reverse(nums, index + 1, length - 1);
    }
    // 交換函式
    private void Swap(int[] nums, int index, int i) {
        int temp = nums[index];
        nums[index] = nums[i];
        nums[i] = temp;
    }
    // 反轉函式
    private void Reverse(int[] nums, int start, int end) {
        while (start < end) {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }
}