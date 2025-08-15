public class Solution {
    public int MaxProduct(int[] nums) {
        int currentMax = nums[0], currentMin = nums[0], max = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            int num = nums[i];

            // 乘積數字為負數會改變最大和最小值
            if (num < 0) {
                int temp = currentMax;
                currentMax = currentMin;
                currentMin = temp;
            }
            // 更新最大和最小乘積值
            currentMax = Math.Max(num, currentMax * num);
            currentMin = Math.Min(num, currentMin * num);
            max = Math.Max(max, currentMax);
        }
        return max;
    }
}