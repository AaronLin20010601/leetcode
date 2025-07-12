function isMatch(s: string, p: string): boolean {
    // 紀錄字串對應結果
    const matchMap = new Map<string, boolean>();

    // 檢查 s 的對應字段是否和 p 匹配
    function checkMatch(i: number, j: number): boolean {
        // 避免重複計算
        const key: string = `${i},${j}`;
        if (matchMap.has(key)) {
            return matchMap.get(key)!;
        }

        // 檢查 p 結束時 s 是否結束
        if (j === p.length) {
            return i === s.length;
        }

        // 檢查當前雙方字元是否相同
        const charMatch: boolean = i < s.length && (s[i] === p[j] || p[j] === '.');
        let result: boolean;

        // 檢查有 * 的情況(跳過或多次重複)
        if (j + 1 < p.length && p[j + 1] === '*') {
            result = checkMatch(i, j + 2) || (charMatch && checkMatch(i + 1, j));
        }
        // 檢查一般情況
        else {
            result = charMatch && checkMatch(i + 1, j + 1);
        }

        matchMap.set(key, result);
        return result;
    }
    return checkMatch(0, 0);
};