public class Solution {
    public int CountRangeSum(int[] nums, int lower, int upper) {
        int number = nums.Length;
        long[] prefixSum = new long[number + 1];

        // 初始化前綴總和
        for (int i = 0; i < number; i++) {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        return (int)CountValidRange(prefixSum, 0, number, lower, upper);
    }
    // 計算符合範圍內總和的陣列範圍數量
    private long CountValidRange(long[] prefixSum, int leftBound, int rightBound, int lower, int upper) {
        if (leftBound >= rightBound) {
            return 0;
        }
        // divide and conquer 分割遞迴檢查符合條件的數量
        int mid = (leftBound + rightBound) / 2;
        long rangeCount = CountValidRange(prefixSum, leftBound, mid, lower, upper) + 
        CountValidRange(prefixSum, mid + 1, rightBound, lower, upper);

        int rightLowerBound = mid + 1, rightUpperBound = mid + 1;
        // 歷遍左側範圍前綴區間
        for (int left = leftBound; left <= mid; left++) {
            // 移動右側區間下限以符合範圍條件
            while (rightLowerBound <= rightBound && prefixSum[rightLowerBound] - prefixSum[left] < lower) {
                rightLowerBound++;
            }
            // 移動右側區間上限以符合範圍條件
            while (rightUpperBound <= rightBound && prefixSum[rightUpperBound] - prefixSum[left] <= upper) {
                rightUpperBound++;
            }
            rangeCount += (rightUpperBound - rightLowerBound);
        }

        // 合併左右半區
        long[] merged = new long[rightBound - leftBound + 1];
        int leftIndex = leftBound, rightIndex = mid + 1, mergedIndex = 0;
        while (leftIndex <= mid && rightIndex <= rightBound) {
            if (prefixSum[leftIndex] <= prefixSum[rightIndex]) {
                merged[mergedIndex] = prefixSum[leftIndex];
                leftIndex++;
            }
            else {
                merged[mergedIndex] = prefixSum[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
        }

        // 將剩餘未放入數字放入合併陣列
        while (leftIndex <= mid) {
            merged[mergedIndex] = prefixSum[leftIndex];
            leftIndex++;
            mergedIndex++;
        }
        while (rightIndex <= rightBound) {
            merged[mergedIndex] = prefixSum[rightIndex];
            rightIndex++;
            mergedIndex++;
        }
        Array.Copy(merged, 0, prefixSum, leftBound, merged.Length);
        return rangeCount;
    }
}