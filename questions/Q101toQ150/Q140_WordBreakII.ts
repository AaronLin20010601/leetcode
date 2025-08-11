function wordBreak(s: string, wordDict: string[]): string[] {
    const sLength: number = s.length;
    const wordSet = new Set(wordDict);

    // 取得單字組中最大單字長度
    let maxLength: number = 0;
    for (const word of wordDict) {
        if (word.length > maxLength) {
            maxLength = word.length;
        }
    }

    // 使用 dynamic programming 檢查是否可分割為集合單字
    const dp: boolean[] = new Array(sLength + 1).fill(false);
    dp[sLength] = true;
    for (let i: number = sLength - 1; i >= 0; i--) {
        for (let wordLength: number = 1; wordLength <= maxLength && i + wordLength <= sLength; wordLength++) {
            if (wordSet.has(s.substring(i, i + wordLength)) && dp[i + wordLength]) {
                dp[i] = true;
                break;
            }
        }
    }

    // 使用深度優先搜尋遞迴檢查可能組合
    const map: Map<number, string[]> = new Map();
    function findCombination(i: number): string[] {
        if (map.has(i)) {
            return map.get(i)!;
        }
        const result: string[] = [];
        // 長度相等代表完整切割完成
        if (i === sLength) {
            result.push("");
            map.set(i, result);
            return result;
        }
        // 無匹配長度單字
        if (!dp[i]) {
            map.set(i, []);
            return [];
        }

        for (let wordLength: number = 1; wordLength <= maxLength && i + wordLength <= sLength; wordLength++) {
            const word: string = s.substring(i, i + wordLength);
            // 無匹配單字和長度
            if (!wordSet.has(word) || !dp[i + wordLength]) {
                continue;
            }

            // 遞迴分割子字串
            const tails: string[] = findCombination(i + wordLength);
            for (const tail of tails) {
                result.push(tail === "" ? word : word + " " + tail);
            }
        }
        map.set(i, result);
        return result;
    }
    return findCombination(0);
};