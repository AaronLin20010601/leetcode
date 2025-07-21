public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> result = new List<int[]>();
        int index = 0, length = intervals.Length;

        // 加入比新區間範圍小的區間
        while (index < length && intervals[index][1] < newInterval[0]) {
            result.Add(intervals[index]);
            index++;
        }
        // 合併與新區間重疊的區間
        while (index < length && intervals[index][0] <= newInterval[1]) {
            newInterval[0] = Math.Min(newInterval[0], intervals[index][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[index][1]);
            index++;
        }
        result.Add(newInterval);
        // 加入比新區間範圍大的區間
        while (index < length) {
            result.Add(intervals[index]);
            index++;
        }
        return result.ToArray();
    }
}