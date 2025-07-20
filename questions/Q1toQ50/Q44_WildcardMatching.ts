function isMatch(s: string, p: string): boolean {
    const sLength: number = s.length;
    const pLength: number = p.length;

    // 使用 dynamic programming 表格紀錄
    const dp: boolean[][] = Array.from({ length: sLength + 1 }, () => Array(pLength + 1).fill(false));
    dp[0][0] = true;

    // 第一列初始化
    for (let i: number = 1; i <= pLength; i++) {
        // 檢查有 * 的情況(跳過或多次重複)
        if (p[i - 1] === '*') {
            dp[0][i] = dp[0][i - 1];
        }
    }
    // 進行 dynamic programming 檢查
    for (let i: number = 1; i <= sLength; i++) {
        for (let j: number = 1; j <= pLength; j++) {
            // 檢查有 * 的情況(跳過或多次重複)
            if (p[j - 1] === '*') {
                dp[i][j] = dp[i][j - 1] || dp[i - 1][j];
            }
            // 檢查單字元情況
            else if (p[j - 1] === '?' || p[j - 1] === s[i - 1]) {
                dp[i][j] = dp[i - 1][j - 1];
            }
        }
    }
    return dp[sLength][pLength];
};