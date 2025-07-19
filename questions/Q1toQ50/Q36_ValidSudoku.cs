public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // 每一欄,列和每一個 3x3 格子
        bool[,] rows = new bool[9, 9];
        bool[,] cols = new bool[9, 9];
        bool[,] boxes = new bool[9, 9];

        for (int row = 0; row < 9; row++) {
            for (int col = 0; col < 9; col++) {
                char block = board[row][col];
                // 跳過空格
                if (block == '.') continue;

                int num = block - '1';
                // 取得數字的所屬 3x3 格子
                int box = (row / 3) * 3 + (col / 3);
                // 檢查有無重複數字
                if (rows[row, num] || cols[col, num] || boxes[box, num]) {
                    return false;
                }
                // 無重複則紀錄
                rows[row, num] = true;
                cols[col, num] = true;
                boxes[box, num] = true;
            }
        }
        return true;
    }
}