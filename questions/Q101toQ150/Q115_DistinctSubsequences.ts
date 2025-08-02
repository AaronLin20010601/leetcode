function numDistinct(s: string, t: string): number {
    const sLength: number = s.length;
    const tLength: number = t.length;
    const dp: number[][] = Array.from({ length: sLength + 1 }, () => Array(tLength + 1).fill(0));

    // 初始化第一欄
    for (let i: number = 0; i <= sLength; i++) {
        dp[i][0] = 1;
    }
    // 使用 dynamic programming 進行可能性查找
    for (let i: number = 1; i <= sLength; i++) {
        for (let j: number = 1; j <= tLength; j++) {
            // 若當前字元相同,則可匹配或跳過
            if (s[i - 1] === t[j - 1]) {
                dp[i][j] = dp[i - 1][j - 1] + dp[i - 1][j];
            }
            // 當前字元不同則只能跳過
            else {
                dp[i][j] = dp[i - 1][j];
            }
        }
    }
    return dp[sLength][tLength];
};