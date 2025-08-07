function findLadders(beginWord: string, endWord: string, wordList: string[]): string[][] {
    const wordSet = new Set(wordList);
    // 不包含目標單字則直接結束
    if (!wordSet.has(endWord)) {
        return [];
    };

    // 檢查 a~z 進行單字字元變化來尋找鄰近單字
    function getNeighbors(word: string): string[] {
        const neighbors: string[] = [];
        for (let i: number = 0; i < word.length; i++) {
            const originalChar = word[i];

            for (let char: number = 97; char < 123; char++) {
                const newChar = String.fromCharCode(char);
                // 字元和原本相同則跳過
                if (newChar === originalChar) {
                    continue;
                }

                const newWord = word.slice(0, i) + newChar + word.slice(i + 1);
                // 單字組中有該單字則加入鄰近單字列表
                if (wordSet.has(newWord)) {
                    neighbors.push(newWord);
                }
            }
        }
        return neighbors;
    }

    // 使用廣度優先搜尋取得最短路徑
    const distance: Map<string, number> = new Map();
    const parents: Map<string, string[]> = new Map();
    const queue: string[] = [beginWord];
    distance.set(beginWord, 0);
    parents.set(beginWord, []);

    while (queue.length > 0) {
        const word = queue.shift()!;
        const currentDistance = distance.get(word)!;

        // 歷遍檢查鄰近單字和現有單字距離
        for (const neighbor of getNeighbors(word)) {
            // 距離表中尚未紀錄該鄰近單字
            if (!distance.has(neighbor)) {
                distance.set(neighbor, currentDistance + 1);
                queue.push(neighbor);
                parents.set(neighbor, [word]);
            }
            // 距離表中已有該鄰近單字且距離為一
            else if (distance.get(neighbor)! === currentDistance + 1) {
                (parents.get(neighbor) || []).push(word);
            }
        }
    }
    
    // 使用深度優先搜尋找出所有到目標單字的最短修改路徑
    function findPath(word: string): string[][] {
        if (word === beginWord) {
            return [[beginWord]];
        }
        const paths: string[][] = [];
        const parentWords = parents.get(word) || [];

        // 歷遍路徑上層單字並遞迴檢查路徑
        for (const parent of parentWords) {
            for (const path of findPath(parent)) {
                paths.push([...path, word]);
            }
        }
        return paths;
    }
    return findPath(endWord);
};