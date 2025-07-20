public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") {
            return "0";
        }

        int length1 = num1.Length, length2 = num2.Length;
        int[] result = new int[length1 + length2];
        // 以 num1 對 num2 每位數字進行乘算
        for (int i = length1 - 1; i >= 0; i--) {
            int digit1 = num1[i] - '0';
            for (int j = length2 - 1; j >= 0; j--) {
                int digit2 = num2[j] - '0';
                int multiply = digit1 * digit2;

                // 進行當前位數和進位分隔
                int carryIndex = i + j;
                int currentIndex = i + j + 1;
                int sum = multiply + result[currentIndex];

                result[currentIndex] = sum % 10;
                result[carryIndex] += sum / 10;
            }
        }
        // 將得出數字轉換回字串
        StringBuilder answer = new StringBuilder();
        foreach (int digit in result) {
            if (!(answer.Length == 0 && digit == 0)) {
                answer.Append(digit);
            }
        }
        return answer.ToString();
    }
}