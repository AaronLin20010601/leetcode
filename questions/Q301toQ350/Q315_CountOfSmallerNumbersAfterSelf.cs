public class Solution {
    private int[] fenwickTree;
    private int unique;
    public IList<int> CountSmaller(int[] nums) {
        int number = nums.Length;

        // 篩選不重複數字並依大小排序
        int[] sorted = new int[number];
        Array.Copy(nums, sorted, number);
        Array.Sort(sorted);
        List<int> uniqueNumber = new List<int>();
        uniqueNumber.Add(sorted[0]);
        for (int i = 1; i < number; i++) {
            if (sorted[i] != sorted[i - 1]) {
                uniqueNumber.Add(sorted[i]);
            }
        }

        // 建立數字大小排序
        unique = uniqueNumber.Count;
        var rank = new Dictionary<int, int>(unique);
        for (int i = 0; i < unique; i++) {
            rank[uniqueNumber[i]] = i + 1;
        }

        // 更新陣列數值並記錄至樹狀陣列
        fenwickTree = new int[unique + 1];
        var result = new int[number];
        for (int i = number - 1; i >= 0; i--) {
            int rk = rank[nums[i]];
            result[i] = PrefixSum(rk - 1);
            UpdateNumber(rk, 1);
        }
        return new List<int>(result);
    }
    // 計算數值總和
    private int PrefixSum(int index) {
        int sum = 0;
        for (int i = index; i > 0; i -= i & -i) {
            sum += fenwickTree[i];
        }
        return sum;
    }
    // 更新樹狀陣列差值
    private void UpdateNumber(int index, int delta) {
        for (int i = index; i <= unique; i += i & -i) {
            fenwickTree[i] += delta;
        }
    }
}