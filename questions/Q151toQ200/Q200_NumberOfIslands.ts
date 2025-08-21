function numIslands(grid: string[][]): number {
    const rowLength: number = grid.length;
    const colLength: number = grid[0].length;
    let island: number = 0;

    // 使用深度優先搜尋遞迴檢查四個方位的陸地
    function checkLand(row: number, col: number) {
        if (row < 0 || row >= rowLength || col < 0 || col >= colLength || grid[row][col] === '0') {
            return;
        }

        // 將已經歷遍的陸地區域改為水域
        grid[row][col] = '0';
        // 遞迴檢查四個方位
        checkLand(row + 1, col);
        checkLand(row - 1, col);
        checkLand(row, col + 1);
        checkLand(row, col - 1);
    }
    // 逐一檢查陸地區域
    for (let row: number = 0; row < rowLength; row++) {
        for (let col: number = 0; col < colLength; col++) {
            if (grid[row][col] === '1') {
                island++;
                checkLand(row, col);
            }
        }
    }
    return island;
};