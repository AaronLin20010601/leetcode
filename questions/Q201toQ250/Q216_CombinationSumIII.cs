public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var result = new List<IList<int>>();
        var path = new List<int>();
        DFSSearch(1, k, n, path, result);
        return result;
    }
    // 使用深度優先搜尋查找所有可能組合
    private void DFSSearch(int start, int numsLeft, int target, List<int> path, List<IList<int>> result) {
        // 可用數字數量用盡且符合目標加總
        if (numsLeft == 0 && target == 0) {
            result.Add(new List<int>(path));
            return;
        }

        // 數字數量不足以到達目標加總數字
        if (9 - start + 1 < numsLeft) {
            return;
        }

        // 最小的可能加總值和最大的可能加總值
        int minBound = numsLeft * (2 * start + numsLeft - 1) / 2;
        int maxBound = numsLeft * (2 * 9 - (numsLeft - 1)) / 2;
        if (minBound > target || maxBound < target) {
            return;
        }

        for (int i = start; i <= 10 - numsLeft; i++) {
            if (i > target) {
                break;
            }
            path.Add(i);
            // 繼續下一層的檢查
            DFSSearch(i + 1, numsLeft - 1, target - i, path, result);
            // 返回至上一層
            path.RemoveAt(path.Count - 1);
        }
    }
}