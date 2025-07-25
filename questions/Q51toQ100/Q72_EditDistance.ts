function minDistance(word1: string, word2: string): number {
    const length1: number = word1.length;
    const length2: number = word2.length;

    // 使用 dynamic programming 紀錄更改次數
    const dp: number[][] = Array.from({ length: length1 + 1 }, () => Array(length2 + 1).fill(0));
    // 初始化左邊界和上邊界
    for (let i: number = 0; i <= length1; i++) {
        dp[i][0] = i;
    }
    for (let i: number = 0; i <= length2; i++) {
        dp[0][i] = i;
    }

    // 進行步數填空
    for (let i: number = 1; i <= length1; i++) {
        for (let j: number = 1; j <= length2; j++) {
            // 字元相同則與上一步數相同
            if (word1[i - 1] === word2[j - 1]) {
                dp[i][j] = dp[i - 1][j - 1];
            }
            // 需要刪除,加入或取代字元
            else {
                dp[i][j] = 1 + Math.min(dp[i - 1][j], dp[i][j - 1], dp[i - 1][j - 1]);
            }
        }
    }
    return dp[length1][length2];
};