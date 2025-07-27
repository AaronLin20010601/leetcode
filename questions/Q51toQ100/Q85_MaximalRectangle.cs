public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        int maxArea = 0;
        int[] heights = new int[cols];

        for (int i = 0; i < rows; i++) {
            // 計算此列柱子高度
            for (int j = 0; j < cols; j++) {
                if (matrix[i][j] == '1') {
                    heights[j] += 1;
                }
                else {
                    heights[j] = 0;
                }
            }
            maxArea = Math.Max(maxArea, LargestArea(heights));
        }
        return maxArea;
    }
    // 使用一維陣列 stack 方式計算面積
    private int LargestArea(int[] heights) {
        int maxArea = 0, length = heights.Length;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i <= length; i++) {
            int currentHeight = (i == length) ? 0 : heights[i];

            // 當前新增柱子高度變低則計算前面柱子面積
            while (stack.Count > 0 && currentHeight < heights[stack.Peek()]) {
                int height = heights[stack.Pop()];
                // 當前位置和前方柱子位置減去自身柱子即為寬度
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }
            stack.Push(i);
        }
        return maxArea;
    }
}