public class Solution {
    public int MaxPoints(int[][] points) {
        int pointAmount = points.Length;
        if (pointAmount <= 2) {
            return pointAmount;
        }

        int maxPointLine = 0;
        // 歷遍檢查每一個點
        for (int i = 0; i < pointAmount; i++) {
            var slopeCount = new Dictionary<(long dx, long dy), int>();
            int duplicates = 0;
            int currentMaxPoints = 0;

            for (int j = i + 1; j < pointAmount; j++) {
                long dx = points[j][0] - points[i][0];
                long dy = points[j][1] - points[i][1];

                // 相同位置點位
                if (dx == 0 && dy == 0) {
                    duplicates++;
                    continue;
                }

                // 逐一檢查該點是否與檢查點有相同比例的 x,y 變量
                var slope = NormalizeSlope(dx, dy);
                if (!slopeCount.ContainsKey(slope)) {
                    slopeCount[slope] = 0;
                }
                slopeCount[slope]++;
                currentMaxPoints = Math.Max(currentMaxPoints, slopeCount[slope]);
            }
            maxPointLine = Math.Max(maxPointLine, currentMaxPoints + duplicates + 1);
        }
        return maxPointLine;
    }
    // 取得線上最小單位的 x,y 變化量
    private (long dx, long dy) NormalizeSlope(long dx, long dy) {
        // 約分 x,y 變化量
        long gcd = GetGCD(Math.Abs(dx), Math.Abs(dy));
        dx /= gcd;
        dy /= gcd;

        // 統一紀錄變化量方向
        if (dx < 0) {
            dx = -dx;
            dy = -dy;
        }
        else if (dx == 0 && dy < 0) {
            dy = -dy;
        }
        return (dx, dy);
    }
    // 取得最大公因數
    private long GetGCD(long a, long b) {
        while (b != 0) {
            long temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }
}