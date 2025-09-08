public class Solution {
    public int[] SingleNumber(int[] nums) {
        var map = new Dictionary<int, int>();

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
        int[] result = new int[2];
        int index = 0;
        foreach (var times in map) {
            if (times.Value == 1) {
                result[index] = times.Key;
                index++;
            }
        }
        return result;
    }
}