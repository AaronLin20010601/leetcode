function exist(board: string[][], word: string): boolean {
    const rows: number = board.length;
    const cols: number = board[0].length;

    // 使用回溯法進行查找
    function backtrack(row: number, col: number, index: number) {
        if (index === word.length) {
            return true;
        }
        // 不符合條件
        if (row < 0 || row >= rows || col < 0 || col >= cols || board[row][col] !== word[index]) {
            return false;
        }
        // 紀錄當前字元並標記為已使用
        const currentChar: string = board[row][col];
        board[row][col] = "#";

        // 往目前格四個方向查找
        const found: boolean = 
            backtrack(row + 1, col, index + 1) || backtrack(row - 1, col, index + 1) ||
            backtrack(row, col + 1, index + 1) || backtrack(row, col - 1, index + 1);
        
        // 回溯至上一層
        board[row][col] = currentChar;
        return found;
    }

    // 逐格查看是否符合條件
    for (let i: number = 0; i < rows; i++) {
        for (let j: number = 0; j < cols; j++) {
            if (backtrack(i, j, 0)) {
                return true;
            }
        }
    }
    return false;
};