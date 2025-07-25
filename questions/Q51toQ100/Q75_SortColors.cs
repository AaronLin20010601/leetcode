public class Solution {
    public void SortColors(int[] nums) {
        QuickSort(nums, 0, nums.Length - 1);
    }
    // 使用 quick sort 方法進行排序
    private void QuickSort(int[] nums, int left, int right) {
        if (left >= right) {
            return;
        }
        int pivot = nums[right], partitionIndex = left;

        // 小於標記點位的數字移動至左側,大於則移動至右側
        for (int i = left; i < right; i++) {
            if (nums[i] < pivot) {
                Swap(nums, i, partitionIndex);
                partitionIndex++;
            }
        }
        Swap(nums, partitionIndex, right);
        QuickSort(nums, left, partitionIndex - 1);
        QuickSort(nums, partitionIndex + 1, right);
    }
    // 數字互換
    private void Swap(int[] nums, int num1, int num2) {
        int temp = nums[num1];
        nums[num1] = nums[num2];
        nums[num2] = temp;
    }
}