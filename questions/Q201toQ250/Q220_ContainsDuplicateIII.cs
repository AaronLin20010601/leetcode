public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff) {
        // 使用桶排序分隔差值範圍數值
        var buckets = new Dictionary<long, long>();
        long size = (long)valueDiff + 1;

        for (int i = 0; i < nums.Length; i++) {
            long num = nums[i];
            long bucketId = GetBucketId(num, size);

            // 數值位於同一桶範圍
            if (buckets.ContainsKey(bucketId)) {
                return true;
            }
            // 數值位於相鄰桶範圍
            if (buckets.ContainsKey(bucketId - 1) && Math.Abs(num - buckets[bucketId - 1]) <= valueDiff) {
                return true;
            }
            if (buckets.ContainsKey(bucketId + 1) && Math.Abs(num - buckets[bucketId + 1]) <= valueDiff) {
                return true;
            }

            buckets[bucketId] = num;
            // 超過數量限制則移除
            if (i >= indexDiff) {
                long oldBucketId = GetBucketId(nums[i - indexDiff], size);
                buckets.Remove(oldBucketId);
            }
        }
        return false;
    }
    // 將數值分配至對應桶
    private long GetBucketId(long num, long size) {
        if (num >= 0) {
            return num / size;
        }
        return ((num + 1) / size) - 1;
    }
}