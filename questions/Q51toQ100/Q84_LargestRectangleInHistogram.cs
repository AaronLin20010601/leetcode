public class Solution {
    public int LargestRectangleArea(int[] heights) {
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