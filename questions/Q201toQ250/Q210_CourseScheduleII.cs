public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // 紀錄課程之間的修課順序關係
        List<int>[] courseRelations = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) {
            courseRelations[i] = new List<int>();
        }

        // 紀錄課程的擋修課程數
        int[] indegree = new int[numCourses];
        foreach (var p in prerequisites) {
            int course = p[0];
            int precourse = p[1];
            courseRelations[precourse].Add(course);
            indegree[course]++;
        }

        // 從可以直接選修的課程開始進行
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                queue.Enqueue(i);
            }
        }

        // 逐一歷遍並記錄當前可修課程
        List<int> order = new List<int>();
        while (queue.Count > 0) {
            int currentCourse = queue.Dequeue();
            order.Add(currentCourse);

            // 解鎖後續課程
            foreach (int nextCourse in courseRelations[currentCourse]) {
                indegree[nextCourse]--;
                if (indegree[nextCourse] == 0) {
                    queue.Enqueue(nextCourse);
                }
            }
        }
        return order.Count == numCourses ? order.ToArray() : new int[0];
    }
}