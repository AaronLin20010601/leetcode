function isInterleave(s1: string, s2: string, s3: string): boolean {
    const length1: number = s1.length, length2: number = s2.length, length3: number = s3.length;
    if (length1 + length2 !== length3) {
        return false;
    }
    
    // 使用 dynamic programming 進行檢查
    const dp: boolean[][] = Array.from({ length: length1 + 1 }, () => Array(length2 + 1).fill(false));
    dp[0][0] = true;

    for (let i: number = 0; i <= length1; i++) {
        for (let j: number = 0; j <= length2; j++) {
            // 上一步仍符合規則時進行檢查並更新狀態
            if (i > 0 && s1[i - 1] === s3[i + j - 1]) {
                dp[i][j] ||= dp[i - 1][j];
            }
            if (j > 0 && s2[j - 1] === s3[i + j - 1]) {
                dp[i][j] ||= dp[i][j - 1];
            }
        }
    }
    return dp[length1][length2];
};