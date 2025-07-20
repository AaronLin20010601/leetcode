public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var result = new List<IList<int>>();
        Array.Sort(candidates);
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }
    // 使用回溯法進行總和可能查找
    private void Backtrack(int[] candidates, int target, int start, List<int> current, IList<IList<int>> result) {
        // 目標數字被減盡,即為找到總和組合並儲存
        if (target == 0) {
            result.Add(new List<int>(current));
            return;
        }
        // 進行可能總和數字組合查找
        for (int i = start; i < candidates.Length; i++) {
            // 跳過同一層的重複數字
            if (i > start && candidates[i] == candidates[i - 1]) {
                continue;
            }
            // 數字總和超過目標
            if (candidates[i] > target) {
                break;
            }

            current.Add(candidates[i]);
            // 下一層進行至 i + 1 避免重複使用同一數字
            Backtrack(candidates, target - candidates[i], i + 1, current, result);
            // 回溯並查找上游可能
            current.RemoveAt(current.Count - 1);
        }
    }
}