public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        var combination = new List<int>();
        var used = new bool[nums.Length];

        Backtrack(nums, combination, used, result);
        return result;
    }
    // 使用回溯法進行所有組合查找
    private void Backtrack(int[] nums, List<int> combination, bool[] used, List<IList<int>> result) {
        // 組合的數字數量和初始陣列相同時即完成一個組合
        if (combination.Count == nums.Length) {
            result.Add(new List<int>(combination));
            return;
        }
        // 若未完成所有數字加入組合則繼續加入
        for (int i = 0; i < nums.Length; i++) {
            // 跳過已使用過的數字
            if (used[i]) {
                continue;
            }
            combination.Add(nums[i]);
            used[i] = true;
            Backtrack(nums, combination, used, result);

            // 回溯並查找上游組合
            combination.RemoveAt(combination.Count - 1);
            used[i] = false;
        }
    }
}