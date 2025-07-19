public class Solution {
    public int MaxArea(int[] height) {
        int area = 0, left = 0, right = height.Length - 1;

        // 從兩邊向內收斂尋找
        while (left < right)
        {
            // 檢查當前和最大面積
            int currentArea = Math.Min(height[left], height[right]) * (right - left);
            if (currentArea > area)
            {
                area = currentArea;
            }

            // 保留長邊並將短邊前推
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return area;
    }
}