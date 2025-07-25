public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> result = new List<IList<int>>();
        List<int> combination = new List<int>();
        Backtrack(nums, 0, combination, result);
        return result;
    }
    // 使用回溯法進行組合查找
    private void Backtrack(int[] nums, int start, List<int> combination, List<IList<int>> result) {
        // 單個數字即為一種組合
        result.Add(new List<int>(combination));

        for (int i = start; i < nums.Length; i++) {
            combination.Add(nums[i]);
            Backtrack(nums, i + 1, combination, result);
            // 回溯至上一層
            combination.RemoveAt(combination.Count - 1);
        }
    }
}