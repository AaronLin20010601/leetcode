public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> numSet = new HashSet<int>(nums);
        int maxLength = 0;

        // 歷遍所有數字進行檢查
        foreach (int num in numSet) {
            if (!numSet.Contains(num - 1)) {
                int current = num;
                int count = 1;

                // 有連續數字時則進行計算
                while (numSet.Contains(current + 1)) {
                    current++;
                    count++;
                }
                maxLength = Math.Max(maxLength, count);
            }
        }
        return maxLength;
    }
}