public class Solution {
    public int[] MaxNumber(int[] nums1, int[] nums2, int k) {
        int[] maximum = new int[k];

        // 從兩個數字陣列中歷遍指定數量中可能的數字組合
        for (int i = Math.Max(0, k - nums2.Length); i <= Math.Min(k, nums1.Length); i++) {
            int[] num1Array = GetMaxSubNumber(nums1, i);
            int[] num2Array = GetMaxSubNumber(nums2, k - i);
            int[] mergedNumber = MergeSubNumbers(num1Array, num2Array, k);

            // 比較當前最大數字組合和當前最大數字組合
            if (CompareNumbers(mergedNumber, maximum, 0, 0)) {
                maximum = mergedNumber;
            }
        }
        return maximum;
    }
    // 從數字陣列中取出最大的數字選擇
    private int[] GetMaxSubNumber(int[] nums, int k) {
        int number = nums.Length;
        int remainNums = number - k;
        List<int> stack = new List<int>();

        // 逐一檢查並選出數字組合
        foreach (int num in nums) {
            // 選出最大的當前位置數字
            while (stack.Count > 0 && stack[stack.Count - 1] < num && remainNums > 0) {
                stack.RemoveAt(stack.Count - 1);
                remainNums--;
            }
            stack.Add(num);
        }
        // 維持指定大小長度
        if (stack.Count > k) {
            stack.RemoveRange(k, stack.Count - k);
        }
        return stack.ToArray();
    }
    // 將兩個數字陣列合併為單獨數字陣列
    private int[] MergeSubNumbers(int[] num1, int[] num2, int k) {
        int[] merged = new int[k];
        int num1Index = 0, num2Index = 0;

        for (int mergedIndex = 0; mergedIndex < k; mergedIndex++) {
            // 第一個數字的當前數字較大則填入
            if (CompareNumbers(num1, num2, num1Index, num2Index)) {
                merged[mergedIndex] = num1[num1Index];
                num1Index++;
            }
            else {
                merged[mergedIndex] = num2[num2Index];
                num2Index++;
            }
        }
        return merged;
    }
    // 比較兩個數字陣列當前位置的數字大小
    private bool CompareNumbers(int[] num1, int[] num2, int num1Index, int num2Index) {
        while (num1Index < num1.Length && num2Index < num2.Length) {
            // 第一個數字陣列的當前數字較大則回傳 true
            if (num1[num1Index] != num2[num2Index]) {
                return num1[num1Index] > num2[num2Index];
            }
            num1Index++;
            num2Index++;
        }
        return (num1.Length - num1Index) > (num2.Length - num2Index);
    }
}