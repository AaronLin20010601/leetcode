function generateParenthesis(n: number): string[] {
    const result: string[] = [];

    // 使用回溯法實作
    function backtrackGenerate(current: string, left: number, right: number) {
        // 單個組合達到兩組括號總量即完成
        if (current.length == 2 * n) {
            result.push(current);
            return;
        }
        // 加入左括號
        if (left < n) {
            backtrackGenerate(current + '(', left + 1, right);
        }
        // 加入右括號
        if (right < left) {
            backtrackGenerate(current + ')', left, right + 1);
        }
    }
    backtrackGenerate('', 0, 0);
    return result;
};