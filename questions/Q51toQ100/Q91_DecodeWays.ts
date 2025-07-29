function numDecodings(s: string): number {
    if (s[0] === '0') {
        return 0;
    }

    // 使用 dynamic programming 進行可能組合計算
    const dp: number[] = new Array(s.length + 1).fill(0);
    dp[0] = 1, dp[1] = 1;

    for (let i: number = 2; i <= s.length; i++) {
        // 分別檢查一位和兩位數字
        const singleDigit: number = Number(s.slice(i - 1, i));
        const doubleDigit: number = Number(s.slice(i - 2, i));

        if (singleDigit >= 1 && singleDigit <= 9) {
            dp[i] += dp[i - 1];
        }
        if (doubleDigit >= 10 && doubleDigit <= 26) {
            dp[i] += dp[i - 2];
        }
    }
    return dp[s.length];
};