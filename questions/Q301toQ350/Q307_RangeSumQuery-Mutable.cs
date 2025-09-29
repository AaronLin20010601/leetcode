public class NumArray {
    private int[] originalNums;
    private int[] fenwickTree;
    private int number;
    public NumArray(int[] nums) {
        // 紀錄初始值
        number = nums.Length;
        originalNums = new int[number];
        fenwickTree = new int[number + 1];

        for (int i = 0; i < number; i++) {
            UpdateNumber(i, nums[i]);
            originalNums[i] = nums[i];
        }
    }
    
    public void Update(int index, int val) {
        // 更新陣列數值並記錄至樹狀陣列
        int delta = val - originalNums[index];
        originalNums[index] = val;
        UpdateNumber(index, delta);
    }
    
    public int SumRange(int left, int right) {
        // 根據數值總和紀錄相減取得總和
        return PrefixSum(right + 1) - PrefixSum(left);
    }
    // 更新樹狀陣列差值
    private void UpdateNumber(int index, int delta) {
        for (int i = index + 1; i <= number; i += i & -i) {
            fenwickTree[i] += delta;
        }
    }
    // 計算數值總和
    private int PrefixSum(int index) {
        int sum = 0;
        for (int i = index; i > 0; i -= i & -i) {
            sum += fenwickTree[i];
        }
        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */