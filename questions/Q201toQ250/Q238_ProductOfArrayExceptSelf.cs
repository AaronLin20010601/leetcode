public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int number = nums.Length;
        int[] result = new int[number];

        // 除自己位置以外的乘積即為左邊乘積乘右邊乘積
        // 從左邊乘積開始放入
        int leftProduct = 1;
        for (int i = 0; i < number; i++) {
            result[i] = leftProduct;
            leftProduct *= nums[i];
        }

        // 乘上右邊乘積
        int rightProduct = 1;
        for (int i = number - 1; i >= 0; i--) {
            result[i] *= rightProduct;
            rightProduct *= nums[i];
        }
        return result;
    }
}