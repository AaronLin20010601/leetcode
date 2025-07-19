function findSubstring(s: string, words: string[]): number[] {
    const result: number[] = [];
    if (s.length === 0 || words.length === 0) return result;

    const wordLength = words[0].length;
    const wordAmount = words.length;
    const windowLength = wordLength * wordAmount;
    if (s.length < windowLength) return result;

    // 統計各單字出現次數
    const wordMap = new Map<string, number>();
    for (const word of words) {
        wordMap.set(word, (wordMap.get(word) || 0) + 1);
    }

    // 使用滑動視窗法逐一檢查
    for (let i: number = 0; i < wordLength; i++) {
        let leftBound: number = i;
        let conformCount: number = 0;
        const seen = new Map<string, number>();

        // 逐單字範圍對比檢查
        for (let j:number = i; j <= s.length - wordLength; j += wordLength) {
            const word = s.substring(j, j + wordLength);

            // 如果存在單字則開始檢查
            if (wordMap.has(word)) {
                seen.set(word, (seen.get(word) || 0) + 1);
                conformCount++;

                // 單字出現次數超過給定單字組次數,則右移視窗邊界
                while ((seen.get(word) || 0) > (wordMap.get(word) || 0)) {
                    const leftWord = s.substring(leftBound, leftBound + wordLength);
                    seen.set(leftWord, (seen.get(leftWord) || 0) - 1);
                    conformCount--;
                    leftBound += wordLength;
                }

                // 出現符合單字組出現次數的範圍則儲存,並繼續往下個單字範圍檢查
                if (conformCount === wordAmount) {
                    result.push(leftBound);
                    const leftWord = s.substring(leftBound, leftBound + wordLength);
                    seen.set(leftWord, (seen.get(leftWord) || 0) - 1);
                    conformCount--;
                    leftBound += wordLength;
                }
            }
            // 出現不符合單字組條件,清除並重置視窗範圍
            else {
                seen.clear();
                conformCount = 0;
                leftBound = j + wordLength;
            }
        }
    }
    return result;
};