public class Solution {
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) {
        int rectangle1 = Math.Abs(ax2 - ax1) * Math.Abs(ay2 - ay1);
        int rectangle2 = Math.Abs(bx2 - bx1) * Math.Abs(by2 - by1);
        // 檢查兩部分面積是否重疊
        if (by1 >= ay2 || ay1 >= by2 || ax2 <= bx1 || bx2 <= ax1) {
            return rectangle1 + rectangle2;
        }

        int overlapWidth = Math.Abs(Math.Min(ax2, bx2) - Math.Max(ax1, bx1));
        int overlapHeight = Math.Abs(Math.Min(ay2, by2) - Math.Max(ay1, by1));
        return rectangle1 + rectangle2 - overlapWidth * overlapHeight;
    }
}