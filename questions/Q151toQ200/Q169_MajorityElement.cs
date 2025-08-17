public class Solution {
    public int MajorityElement(int[] nums) {
        int target = 0, count = 0;

        // 逐一檢查和抵銷數字,最後剩餘的即為最多數
        foreach (int num in nums) {
            if (count == 0) {
                target = num;
                count++;
            }
            else if (num == target) {
                count++;
            }
            else {
                count--;
            }
        }
        return target;
    }
}