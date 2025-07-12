function convert(s: string, numRows: number): string {
    if (numRows === 1 || s.length <= numRows) return s;

    const zigzagRows: string[] = new Array(numRows).fill("");
    let currentRow: number = 0;
    let downward: boolean = false;

    // 將字元放入對應陣列
    for (const character of s) {
        zigzagRows[currentRow] += character;

        // 觸碰邊界改變方向
        if (currentRow === 0 || currentRow === numRows - 1) {
            downward = !downward;
        }
        currentRow += downward ? 1 : -1;
    }
    return zigzagRows.join("");
};