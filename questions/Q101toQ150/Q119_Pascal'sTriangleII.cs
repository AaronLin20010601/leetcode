public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var currentRow = new List<int>();

        // 建立三角形陣列
        for (int i = 0; i <= rowIndex; i++) {
            var row = new List<int>(new int[i + 1]);
            for (int j = 0; j <= i; j++) {
                // 最兩側數字
                if (j == 0 || j == i) {
                    row[j] = 1;
                }
                // 中間數字為上層兩數字加總
                else {
                    row[j] = currentRow[j - 1] + currentRow[j];
                }
            }
            currentRow = row;
        }
        return currentRow;
    }
}