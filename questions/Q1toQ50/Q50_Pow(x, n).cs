public class Solution {
    public double MyPow(double x, int n) {
        long exponent = n;
        // 指數為負數
        if (exponent < 0) {
            x = 1 / x;
            exponent = -exponent;
        }

        double result = 1.0;
        double number = x;
        while (exponent > 0) {
            // 當前指數為奇數
            if ((exponent % 2) == 1) {
                result *= number;
            }
            // 數字平方同時指數減半
            number *= number;
            exponent /= 2;
        }
        return result;
    }
}