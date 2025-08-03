public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var triangle = new List<IList<int>>(numRows);

        // 建立三角形陣列
        for (int i = 0; i < numRows; i++) {
            var row = new List<int>(new int[i + 1]);
            for (int j = 0; j <= i; j++) {
                // 最兩側數字
                if (j == 0 || j == i) {
                    row[j] = 1;
                }
                // 中間數字為上層兩數字加總
                else {
                    row[j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }
            triangle.Add(row);
        }
        return triangle;
    }
}