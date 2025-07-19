public class Solution {
    public int RemoveElement(int[] nums, int val) {
        if (nums.Length == 0) return 0;

        int notVal = 0;
        for (int i = 0; i < nums.Length; i++) {
            // 檢查為非目標數字並移動
            if (nums[i] != val) {
                nums[notVal] = nums[i];
                notVal++;
            }
        }
        return notVal;
    }
}