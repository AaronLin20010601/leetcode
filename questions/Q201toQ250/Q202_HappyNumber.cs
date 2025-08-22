public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> nums = new HashSet<int>();
        
        while (n != 1) {
            n = GetNext(n);

            // 歷遍過的數值重複
            if (nums.Contains(n)) {
                return false;
            }
            nums.Add(n);
        }
        return true;
    }
    // 進行數字平方加總
    private int GetNext(int n) {
        int result = 0;
        while (n > 0) {
            int digit = n % 10;
            result += digit * digit;
            n /= 10;
        }
        return result;
    }
}