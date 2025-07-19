public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // 確保較小陣列位於前面以便操作
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        // 以較小陣列為基準進行分割搜尋
        int length1 = nums1.Length, length2 = nums2.Length;
        int left = 0, right = length1;

        // 找到中點時才結束
        while (left <= right) {
            // 二分搜尋分割點
            int binarySearchPoint1 = (left + right) / 2;
            int binarySearchPoint2 = (length1 + length2 + 1) / 2 - binarySearchPoint1;

            // 四個分割點位子陣列的中間值
            int leftMax1 = (binarySearchPoint1 == 0) ? int.MinValue : nums1[binarySearchPoint1 - 1];
            int rightMin1 = (binarySearchPoint1 == length1) ? int.MaxValue : nums1[binarySearchPoint1];

            int leftMax2 = (binarySearchPoint2 == 0) ? int.MinValue : nums2[binarySearchPoint2 - 1];
            int rightMin2 = (binarySearchPoint2 == length2) ? int.MaxValue : nums2[binarySearchPoint2];

            // 左邊合併陣列皆小於右邊合併陣列
            if (leftMax1 <= rightMin2 && leftMax2 <= rightMin1) {
                if ((length1 + length2) % 2 == 0) {
                    return (Math.Max(leftMax1, leftMax2) + Math.Min(rightMin1, rightMin2)) / 2.0;
                }
                else {
                    return Math.Max(leftMax1, leftMax2);
                }
            }
            // 左邊陣列最大值大於右邊陣列最小值
            else if (leftMax1 > rightMin2) {
                right = binarySearchPoint1 - 1;
            }
            else {
                left = binarySearchPoint1 + 1;
            }
        }
        throw new ArgumentException("Error");
    }
}