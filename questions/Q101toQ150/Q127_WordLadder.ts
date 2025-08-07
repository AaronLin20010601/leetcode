function ladderLength(beginWord: string, endWord: string, wordList: string[]): number {
    const wordSet = new Set(wordList);
    // 不包含目標單字則直接結束
    if (!wordSet.has(endWord)) {
        return 0;
    };

    // 使用廣度優先搜尋取得最短路徑
    const queue: [string, number][] = [[beginWord, 1]];
    const visited = new Set<string>([beginWord]);
    while (queue.length > 0) {
        const [currentWord, depth] = queue.shift()!;

        // 檢查 a~z 進行單字字元變化來尋找鄰近單字
        for (let i: number = 0; i < currentWord.length; i++) {
            for (let c: number = 97; c < 123; c++) {
                const char = String.fromCharCode(c);
                // 字元和原本相同則跳過
                if (char === currentWord[i]) {
                    continue;
                }

                const newWord = currentWord.slice(0, i) + char + currentWord.slice(i + 1);
                // 鄰近單字為目標單字則返回深度
                if (newWord === endWord) {
                    return depth + 1;
                }
                // 單字組中有該單字則加入歷遍單字列表
                if (wordSet.has(newWord) && !visited.has(newWord)) {
                    visited.add(newWord);
                    queue.push([newWord, depth + 1]);
                }
            }
        }
    }
    return 0;
};