public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        // 排序為由小到大
        Array.Sort(nums);
        var result = new List<IList<int>>();

        // 取中心數字左右雙向檢查,從第一個檢查到倒數第二個
        for (int i = 0; i < nums.Length - 2; i++) {
            // 跳過重複數字
            if (i > 0 && nums[i] == nums[i - 1]) {
                continue;
            }

            int left = i + 1, right = nums.Length - 1;
            // 從兩側收斂檢查
            while (left < right) {
                int sum = nums[left] + nums[i] + nums[right];

                // 儲存相加為零結果並跳過重複數字
                if (sum == 0) {
                    result.Add(new List<int> { nums[left], nums[i], nums[right] });

                    while (left < right && nums[left] == nums[left + 1]) {
                        left++;
                    }
                    while (left < right && nums[right] == nums[right - 1]) {
                        right--;
                    }
                    left++;
                    right--;
                }
                // 相加結果過小則左端向中移動
                else if (sum < 0) {
                    left++;
                }
                // 相加結果過大則右端向中移動
                else {
                    right--;
                }
            }
        }
        return result;
    }
}