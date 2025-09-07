public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int number = nums.Length;
        if (k == 1) {
            return nums;
        }

        int[] result = new int[number - k + 1];
        LinkedList<int> list = new LinkedList<int>();

        for (int i = 0; i < number; i++) {
            // 移除超出邊界的值
            while (list.Count > 0 && list.First.Value <= i - k) {
                list.RemoveFirst();
            }
            // 將 list 篩選為遞減值,頭部值必為當前最大值
            while (list.Count > 0 && nums[list.Last.Value] < nums[i]) {
                list.RemoveLast();
            }

            list.AddLast(i);
            if (i >= k - 1) {
                result[i - k + 1] = nums[list.First.Value];
            }
        }
        return result;
    }
}