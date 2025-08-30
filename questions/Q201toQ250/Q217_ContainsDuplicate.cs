public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        if (nums.Length == 1) {
            return false;
        }

        // 使用 hashset 檢查並記錄數字
        var number = new HashSet<int>();
        foreach (int num in nums) {
            // 數字已存在
            if (!number.Add(num)) {
                return true;
            }
        }
        return false;
    }
}