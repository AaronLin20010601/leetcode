public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length <= 1) {
            return intervals;
        }
        Array.Sort(intervals, (front, tail) => front[0].CompareTo(tail[0]));
        List<int[]> result = new List<int[]>();

        // 檢查是否有重疊區間
        foreach (var interval in intervals) {
            // 無重疊
            if (result.Count == 0 || result[result.Count - 1][1] < interval[0]) {
                result.Add(interval);
            }
            // 合併重疊區間
            else {
                result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], interval[1]);
            }
        }
        return result.ToArray();
    }
}