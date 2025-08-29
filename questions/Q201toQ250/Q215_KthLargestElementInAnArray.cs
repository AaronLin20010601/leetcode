public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        // 使用 priority queue 進行查找
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
        foreach (var num in nums) {
            priorityQueue.Enqueue(num, num);
            if (priorityQueue.Count > k) {
                priorityQueue.Dequeue();
            }
        }
        return priorityQueue.Peek();
    }
}