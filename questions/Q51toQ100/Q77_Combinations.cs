public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var result = new List<IList<int>>();
        Backtrack(n, k, 1, new List<int>(), result);
        return result;
    }
    // 使用回溯法進行組合查找
    private void Backtrack(int n, int k, int start, List<int> combination, IList<IList<int>> result) {
        // 已達到要求數字量則加入組合
        if (combination.Count == k) {
            result.Add(new List<int>(combination));
            return;
        }
        for (int i = start; i <= n - (k - combination.Count) + 1; i++) {
            combination.Add(i);
            Backtrack(n, k, i + 1, combination, result);
            // 回溯至上一層
            combination.RemoveAt(combination.Count - 1);
        }
    }
}