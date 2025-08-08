function minCut(s: string): number {
    const sLength: number = s.length;
    const dp: number[] = new Array(sLength).fill(0);
    const isPalindrome: boolean[][] = Array.from({ length: sLength }, () => Array(sLength).fill(false));

    // 檢查子字串是否對稱
    for (let end: number = 0; end < sLength; end++) {
        for (let start: number = 0; start <= end; start++) {
            // 子字串頭尾相同,且中間部分也對稱
            if (s[start] === s[end] && (end - start <= 2 || isPalindrome[start + 1][end - 1])) {
                isPalindrome[start][end] = true;
            }
        }
    }
    // 歷遍字串和子字串檢查是否對稱
    for (let end: number = 0; end < sLength; end++) {
        // 檢查當前子字串是否對稱
        if (isPalindrome[0][end]) {
            dp[end] = 0;
        }
        else {
            dp[end] = end;
            for (let start: number = 1; start <= end; start++) {
                if (isPalindrome[start][end]) {
                    dp[end] = Math.min(dp[end], dp[start - 1] + 1);
                }
            }
        }
    }
    return dp[sLength - 1];
};