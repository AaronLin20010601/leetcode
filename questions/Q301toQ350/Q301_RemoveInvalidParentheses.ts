function removeInvalidParentheses(s: string): string[] {
    const result: string[] = [];
    const visited: Set<string> = new Set();
    const queue: string[] = [];

    // 使用廣度優先搜尋查找結果
    queue.push(s);
    visited.add(s);
    let found: boolean = false;

    // 檢查當前範圍是否符合條件
    while (queue.length > 0) {
        const levelSize: number = queue.length;

        // 逐層檢查是否符合條件
        for (let i: number = 0; i < levelSize; i++) {
            const current: string = queue.shift()!;
            if (checkParenthese(current)) {
                result.push(current);
                found = true;
            }
            // 有符合條件則留在本層
            if (found) {
                continue;
            }
            // 產生需檢查的下一層字串
            for (let j: number = 0; j < current.length; j++) {
                const char: string = current[j];

                // 跳過普通字元
                if (char !== '(' && char !== ')') {
                    continue;
                }
                // 刪除當前位置不對稱括號
                const next: string = current.slice(0, j) + current.slice(j + 1);
                if (!visited.has(next)) {
                    visited.add(next);
                    queue.push(next);
                }
            }
        }
        if (found) {
            break;
        }
    }
    return result.length > 0 ? result : [""];
};
// 檢查左右括號數量
function checkParenthese(s: string): boolean {
    let currentLeft: number = 0;
    for (let i: number = 0; i < s.length; i++) {
        const char: string = s[i];

        // 檢查數量是否對稱
        if (char === '(') {
            currentLeft++;
        }
        else if (char === ')') {
            if (currentLeft === 0) {
                return false;
            }
            currentLeft--;
        }
    }
    return currentLeft === 0;
}