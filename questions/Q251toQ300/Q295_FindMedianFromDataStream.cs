public class MedianFinder {
    // 陣列左半邊的最大值和右半邊的最小值序列
    private PriorityQueue<int, int> maxHeap;
    private PriorityQueue<int, int> minHeap;

    public MedianFinder() {
        maxHeap = new PriorityQueue<int, int>();
        minHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        // 數字加入左半邊
        maxHeap.Enqueue(num, -num);
        // 檢查左半邊最大值是否大於右半邊最小值
        int maxLeft = maxHeap.Dequeue();
        minHeap.Enqueue(maxLeft, maxLeft);

        // 確保左右半邊數量相同或僅差一個
        if (minHeap.Count > maxHeap.Count) {
            int minRight = minHeap.Dequeue();
            maxHeap.Enqueue(minRight, -minRight);
        }
    }
    
    public double FindMedian() {
        // 偶數數量數字
        if (maxHeap.Count == minHeap.Count) {
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
        // 奇數數量數字
        else {
            return maxHeap.Peek();
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */