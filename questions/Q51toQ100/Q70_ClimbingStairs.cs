public class Solution {
    public int ClimbStairs(int n) {
        if (n <= 2) {
            return n;
        }

        // 當前可能性即為前兩輪的可能性總數相加 (fibonacci)
        return Fibonacci(n);
    }
    // fibonacci
    private int Fibonacci(int n) {
        int f1 = 1, f2 = 2;
        for (int i = 3; i <= n; i++) {
            int f3 = f1 + f2;
            f1 = f2;
            f2 = f3;
        }
        return f2;
    }
}