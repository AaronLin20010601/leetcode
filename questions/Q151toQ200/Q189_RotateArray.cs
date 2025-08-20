public class Solution {
    public void Rotate(int[] nums, int k) {
        int numbers = nums.Length;
        k %= numbers;
        if (k == 0) {
            return;
        }

        // 將整體陣列反轉,再分別反轉切點子陣列內數字, 即 front + tail -> tail + front
        Reverse(nums, 0, numbers - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, numbers - 1);
    }
    // 反轉陣列內容
    private void Reverse(int[] array, int leftIndex, int rightIndex) {
        while (leftIndex < rightIndex) {
            (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
            leftIndex++;
            rightIndex--;
        }
    }
}