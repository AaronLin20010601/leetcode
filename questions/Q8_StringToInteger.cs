public class Solution {
    public int MyAtoi(string s) {
        int index = 0, result = 0, sign = 1, length = s.Length;

        // 跳過空格
        while (index < length && s[index] == ' ') {
            index++;
        }

        // 檢查正負號
        if (index < length) {
            if (s[index] == '+') {
                sign = 1;
                index++;
            }
            else if (s[index] == '-') {
                sign = -1;
                index++;
            }
        }

        // 檢查是否為數字字元並轉換
        while (index < length && Char.IsDigit(s[index])) {
            int digit = s[index] - '0';
            // 檢查數字溢出
            if (result > (Int32.MaxValue - digit) / 10) {
                return sign == 1 ? Int32.MaxValue : Int32.MinValue;
            }

            result = result * 10 + digit;
            index++;
        }
        return sign * result;
    }
}