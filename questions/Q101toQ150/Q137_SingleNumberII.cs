public class Solution {
    public int SingleNumber(int[] nums) {
        Dictionary<int, int> map = new Dictionary<int, int>();

        // 計算每個數字的出現次數
        foreach (int num in nums) {
            if (!map.ContainsKey(num)) {
                map[num] = 1;
            }
            else {
                map[num]++;
            }
        }
        // 取得只出現過一次的數字
        foreach (var times in map) {
            if (times.Value == 1) {
                return times.Key;
            }
        }
        return -1;
    }
}