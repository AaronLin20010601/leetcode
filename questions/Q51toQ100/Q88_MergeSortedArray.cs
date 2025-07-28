public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int index1 = m - 1, index2 = n - 1, tail = m + n - 1;

        while (index1 >= 0 && index2 >= 0) {
            // 將當前最大數字放至目前尾端位置
            if (nums1[index1] > nums2[index2]) {
                nums1[tail] = nums1[index1];
                index1--;
            }
            else {
                nums1[tail] = nums2[index2];
                index2--;
            }
            tail--;
        }
        // 放置剩餘 nums2
        while (index2 >= 0) {
            nums1[tail] = nums2[index2];
            index2--;
            tail--;
        }
    }
}