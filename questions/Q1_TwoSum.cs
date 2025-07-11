public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // 使用 hashmap 進行紀錄並最大化降低時間複雜度
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }
            map[nums[i]] = i;
        }
        return new int[0];
    }
}