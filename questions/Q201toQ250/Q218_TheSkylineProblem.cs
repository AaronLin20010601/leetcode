public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var skyline = new List<(int x, int height, bool isStart)>();
        foreach (var build in buildings) {
            // 紀錄左側開始點和右側結束點
            skyline.Add((build[0], build[2], true));
            skyline.Add((build[1], build[2], false));
        }

        // 比較並排序高度變化
        skyline.Sort((a, b) => {
            // x 軸座標較小者順序優先
            if (a.x != b.x) {
                return a.x.CompareTo(b.x);
            }
            // 皆為起始點則較高點順序優先
            if (a.isStart && b.isStart) {
                return b.height.CompareTo(a.height);
            }
            // 皆為結束點則較低點順序優先
            if (!a.isStart && !b.isStart) {
                return a.height.CompareTo(b.height);
            }
            // 起始點順序優先
            return a.isStart ? -1 : 1;
        });

        // 使用 priority queue 紀錄最高點
        var result = new List<IList<int>>();
        var heights = new PriorityQueue<int, int>(); 
        heights.Enqueue(0, 0);
        // 另外記錄要移除的高度
        var removed = new Dictionary<int, int>();
        int previousMaximumHeight = 0;

        foreach (var s in skyline) {
            // 為起始點則加入高度紀錄
            if (s.isStart) {
                heights.Enqueue(s.height, -s.height);
            }
            // 為結束點則紀錄要移除的高度點
            else {
                if (!removed.ContainsKey(s.height)) {
                    removed[s.height] = 0;
                }
                removed[s.height]++;
            }

            // 清除要移除的高度點
            while (heights.Count > 0) {
                int top = heights.Peek();
                if (removed.ContainsKey(top) && removed[top] > 0) {
                    removed[top]--;
                    heights.Dequeue();
                }
                else {
                    break;
                }
            }
            
            // 記錄高度變化點
            int currentMaxHeight = heights.Peek();
            if (currentMaxHeight != previousMaximumHeight) {
                result.Add(new List<int>{ s.x, currentMaxHeight });
                previousMaximumHeight = currentMaxHeight;
            }
        }
        return result;
    }
}