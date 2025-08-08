/**
 Do not return anything, modify board in-place instead.
 */
function solve(board: string[][]): void {
    const row: number = board.length, col: number = board[0].length;
    const directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];

    function checkSurround(rowIndex: number, colIndex: number) {
        if (rowIndex < 0 || colIndex < 0 || rowIndex >= row || colIndex >= col || board[rowIndex][colIndex] !== 'O') {
            return;
        }
        // 將標記改為沒被包圍
        board[rowIndex][colIndex] = 'T';
        // 檢查其他四個方向
        for (const [dx, dy] of directions) {
            checkSurround(rowIndex + dx, colIndex + dy);
        }
    }
    
    // 檢查邊界和其鄰近位置是否有沒被包圍的標記
    for (let i: number = 0; i < row; i++) {
        if (board[i][0] === 'O') {
            checkSurround(i, 0);
        }
        if (board[i][col - 1] === 'O') {
            checkSurround(i, col - 1);
        }
    }
    for (let i: number = 0; i < col; i++) {
        if (board[0][i] === 'O') {
            checkSurround(0, i);
        }
        if (board[row - 1][i] === 'O') {
            checkSurround(row - 1, i);
        }
    }

    // 把被包圍的標記改為 X 並把沒被包圍的標記 T 改回 O
    for (let i: number = 0; i < row; i++) {
        for (let j: number = 0; j < col; j++) {
            if (board[i][j] === 'O') {
                board[i][j] = 'X';
            }
            else if (board[i][j] === 'T') {
                board[i][j] = 'O';
            }
        }
    }
};