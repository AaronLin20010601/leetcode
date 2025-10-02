public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1) {
            return new List<int> { 0 };
        }

        // 紀錄節點相鄰關係
        List<int>[] neighbors = new List<int>[n];
        for (int i = 0; i < n; i++) {
            neighbors[i] = new List<int>();
        }
        foreach (var e in edges) {
            neighbors[e[0]].Add(e[1]);
            neighbors[e[1]].Add(e[0]);
        }

        // 紀錄每個節點為起點到最遠距離的節點
        int GetFurthestNode(int startNode, out Dictionary<int,int> parent) {
            parent = new Dictionary<int,int>();
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(startNode);
            parent[startNode] = -1;
            int lastNode = startNode;

            // 逐一尋找當前最後節點並記錄路徑
            while (queue.Count > 0) {
                int node = queue.Dequeue();
                lastNode = node;
                foreach (var neighbor in neighbors[node]) {
                    if (!parent.ContainsKey(neighbor)) {
                        parent[neighbor] = node;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return lastNode;
        }

        // 進行兩次廣度優先搜尋以找到最長路徑
        var furthestNode = GetFurthestNode(0, out _);
        var root = GetFurthestNode(furthestNode, out var parent);

        // 進行最長路徑回溯
        List<int> path = new List<int>();
        for (int node = root; node != -1; node = parent[node]) {
            path.Add(node);
        }
        path.Reverse();

        int pathLength = path.Count;
        // 奇數長度只會有一個中心長度節點,偶數則會有兩個
        if (pathLength % 2 == 1) {
            return new List<int> { path[pathLength / 2] };
        }
        else {
            return new List<int> { path[pathLength / 2 - 1], path[pathLength / 2] };
        }
    }
}