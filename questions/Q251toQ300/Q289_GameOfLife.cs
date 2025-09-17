public class Solution {
    public void GameOfLife(int[][] board) {
        int row = board.Length, col = board[0].Length;
        
        // 進行下一代細胞紀錄
        int[][] nextBoard = new int[row][];
        for (int i = 0; i < row; i++) {
            nextBoard[i] = new int[col];
        }
        int[] dx = {-1,-1,-1,0,0,1,1,1};
        int[] dy = {-1,0,1,-1,1,-1,0,1};

        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                int liveNeighbors = 0;

                // 計算活細胞鄰居數
                for (int k = 0; k < 8; k++) {
                    int neighbori = i + dx[k], neighborj = j + dy[k];

                    if (neighbori >= 0 && neighbori < row && neighborj >= 0 && neighborj < col) {
                        liveNeighbors += board[neighbori][neighborj];
                    }
                }

                // 判斷下一代活細胞
                if (board[i][j] == 1) {
                    nextBoard[i][j] = (liveNeighbors == 2 || liveNeighbors == 3) ? 1 : 0;
                }
                else {
                    nextBoard[i][j] = (liveNeighbors == 3) ? 1 : 0;
                }
            }
        }
        // 寫回原版面
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                board[i][j] = nextBoard[i][j];
            }
        }
    }
}