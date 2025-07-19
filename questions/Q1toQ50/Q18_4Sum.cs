public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        // 排序為由小到大
        Array.Sort(nums);
        var result = new List<IList<int>>();

        // 最外層,第一個數字
        for (int first = 0; first < nums.Length - 3; first++) {
            // 跳過重複數字
            if (first > 0 && nums[first] == nums[first - 1]) {
                continue;
            }
            // 第二層,第二個數字
            for (int second = first + 1; second < nums.Length - 2; second++) {
                // 跳過重複數字
                if (second > first + 1 && nums[second] == nums[second - 1]) {
                    continue;
                }

                int left = second + 1, right = nums.Length - 1;
                // 第三和第四個數字從兩側收斂檢查
                while (left < right) {
                    long sum = (long)nums[first] + nums[second] + nums[left] + nums[right];

                    // 儲存相加為目標數字並跳過重複數字
                    if (sum == target) {
                        result.Add(new List<int> { nums[first], nums[second], nums[left], nums[right] });

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
                    else if (sum < target) {
                        left++;
                    }
                    // 相加結果過大則右端向中移動
                    else {
                        right--;
                    }
                }
            }
        }
        return result;
    }
}