public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        int numbers = nums.Length;
        int? num1 = null, num2 = null;
        int count1 = 0, count2 = 0;

        // 逐一歷遍抵銷陣列數字(提供條件最多只會有兩個符合要求的數字)
        foreach (int num in nums) {
            // 紀錄當前數字數量
            if (num1.HasValue && num == num1.Value) {
                count1++;
            }
            else if (num2.HasValue && num == num2.Value) {
                count2++;
            }
            // 替換當前數字
            else if (count1 == 0) {
                num1 = num;
                count1++;
            }
            else if (count2 == 0) {
                num2 = num;
                count2++;
            }
            // 皆非當前紀錄的數字
            else {
                count1--;
                count2--;
            }
        }

        count1 = 0;
        count2 = 0;
        // 檢查紀錄數字出現次數是否達標
        foreach (int num in nums) {
            if (num1.HasValue && num == num1.Value) {
                count1++;
            }
            if (num2.HasValue && num == num2.Value) {
                count2++;
            }
        }

        var result = new List<int>();
        if (count1 > numbers / 3) {
            result.Add(num1.Value);
        }
        if (count2 > numbers / 3 && num2 != num1) {
            result.Add(num2.Value);
        }
        return result;
    }
}