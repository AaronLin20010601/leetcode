public class Solution {
    // 每一欄,列和每一個 3x3 格子
    private bool[,] rows = new bool[9, 9];
    private bool[,] cols = new bool[9, 9];
    private bool[,] boxes = new bool[9, 9];
    
    public void SolveSudoku(char[][] board) {
        // 初始化現有數字
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                char block = board[i][j];
                if (block != '.') {
                    int num = block - '1';
                    rows[i, num] = true;
                    cols[j, num] = true;
                    boxes[GetBoxIndex(i, j), num] = true;
                }
            }
        }
        Backtrack(board, 0, 0);
    }
    // 使用回溯法進行填空
    private bool Backtrack(char[][] board, int row, int col) {
        // 移動至下一行
        if (col == 9) {
            row++;
            col = 0;
        }
        // 完成數字填空
        if (row == 9) {
            return true;
        }
        // 遇到已有數字的格子
        if (board[row][col] != '.') {
            return Backtrack(board, row, col + 1);
        }
        // 嘗試填入數字
        for (int num = 0; num < 9; num++) {
            // 檢查是否有重複數字
            if (!rows[row, num] && !cols[col, num] && !boxes[GetBoxIndex(row, col), num]) {
                board[row][col] = (char)(num + '1');
                rows[row, num] = cols[col, num] = boxes[GetBoxIndex(row, col), num] = true;
                if (Backtrack(board, row, col + 1)) {
                    return true;
                }
                
                // 若無法依照規則填入則回溯
                board[row][col] = '.';
                rows[row, num] = cols[col, num] = boxes[GetBoxIndex(row, col), num] = false;
            }
        }
        return false;
    }
    // 取得數字所屬的 3x3 格子
    private int GetBoxIndex(int row, int col) {
        return (row / 3) * 3 + (col / 3);
    }
}