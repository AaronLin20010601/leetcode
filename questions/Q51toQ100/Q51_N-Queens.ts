function solveNQueens(n: number): string[][] {
    const result: string[][] = [];
    // 紀錄皇后位置
    const board: number[] = [];

    // 檢查是否可放置皇后
    function isValid(row: number, col: number): boolean {
        for (let previousRow: number = 0; previousRow < row; previousRow++) {
            const previousCol: number = board[previousRow];
            // 皇后位置衝突
            if (previousCol === col || Math.abs(previousCol - col) === Math.abs(previousRow - row)) {
                return false;
            }
        }
        return true;
    }
    // 使用回溯法尋找不會衝突的組合
    function backtrack(row: number): void {
        // 完成所有列的放置,轉換為棋盤陣列
        if (row === n) {
            const solution: string[] = board.map(col => {
                const rowArray = Array(n).fill('.');
                rowArray[col] = 'Q';
                return rowArray.join('');
            });
            result.push(solution);
            return;
        }
        for (let col = 0; col < n; col++) {
            // 不會衝突則放置皇后
            if (isValid(row, col)) {
                board[row] = col;
                backtrack(row + 1);
            }
        }
    }
    backtrack(0);
    return result;
};