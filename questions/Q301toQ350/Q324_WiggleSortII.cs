public class Solution {
    public void WiggleSort(int[] nums) {
        int number = nums.Length;
        if (number == 1) {
            return;
        }

        // 複製一個排序過後的陣列,並從中位數切割位置
        int[] sorted = new int[number];
        Array.Copy(nums, sorted, number);
        Array.Sort(sorted);

        int leftIndex = (number + 1) / 2 - 1;
        int rightIndex = number - 1;
        // 依照陣列順序放入較小數和較大數
        for (int i = 0; i < number; i++) {
            if ((i & 1) == 0) {
                nums[i] = sorted[leftIndex];
                leftIndex--;
            }
            else {
                nums[i] = sorted[rightIndex];
                rightIndex--;
            }
        }
    }
}