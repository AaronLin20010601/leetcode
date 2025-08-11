function wordBreak(s: string, wordDict: string[]): boolean {
    const sLength: number = s.length;
    const wordSet = new Set(wordDict);

    // 取得單字組中最大單字長度
    let maxLength: number = 0;
    for (const word of wordDict) {
        if (word.length > maxLength) {
            maxLength = word.length;
        }
    }

    // 使用 dynamic programming 進行檢查
    const dp: boolean[] = new Array(sLength + 1).fill(false);
    dp[0] = true;
    for (let i: number = 1; i <= sLength; i++) {
        // 依照當前範圍進行檢查
        const start: number = Math.max(0, i - maxLength);
        for (let j: number = start; j < i; j++) {
            if (!dp[j]) {
                continue;
            }
            // 檢查該子字串是否為集合單字
            const sub: string = s.substring(j, i);
            if (wordSet.has(sub)) {
                dp[i] = true;
                break;
            }
        }
    }
    return dp[sLength];
};