public class Solution {
    public int FindDuplicate(int[] nums) {
        int slow = nums[0], fast = nums[0];

        // 使用快慢指針和 index/value 值查找閉環相遇點
        do {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        // 尋找閉環起點(重複數字)
        slow = nums[0];
        while (slow != fast) {
            slow = nums[slow];
            fast = nums[fast];
        }
        return slow;
    }
}