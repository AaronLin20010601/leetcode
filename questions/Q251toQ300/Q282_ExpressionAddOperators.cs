public class Solution {
    private IList<string> result;

    public IList<string> AddOperators(string num, int target) {
        result = new List<string>();
        Backtrack(num, target, 0, 0L, 0L, new StringBuilder());
        return result;
    }
    // 使用回溯法遞迴檢查可能的組合
    private void Backtrack(string num, int target, int index, long sum, long lastNum, StringBuilder expression) {
        int number = num.Length;
        // 找到符合目標的組合
        if (index == number && sum == target) {
            result.Add(expression.ToString());
            return;
        }

        for (int i = index; i < number; i++) {
            // 跳過 0 開頭數值
            if (i != index && num[index] == '0') {
                break;
            }

            string currentNum = num.Substring(index, i - index + 1);
            long current = long.Parse(currentNum);
            int previousLength = expression.Length;

            // 開頭的第一個數值
            if (index == 0) {
                expression.Append(currentNum);
                Backtrack(num, target, i + 1, current, current, expression);
                // 回溯至上一層
                expression.Length = previousLength;
            }
            else {
                // 檢查加法
                expression.Append('+').Append(currentNum);
                Backtrack(num, target, i + 1, sum + current, current, expression);
                expression.Length = previousLength;

                // 檢查減法
                expression.Append('-').Append(currentNum);
                Backtrack(num, target, i + 1, sum - current, -current, expression);
                expression.Length = previousLength;

                // 檢查乘法
                expression.Append('*').Append(currentNum);
                Backtrack(num, target, i + 1, sum - lastNum + lastNum * current, lastNum * current, expression);
                expression.Length = previousLength;
            }
        }
    }
}