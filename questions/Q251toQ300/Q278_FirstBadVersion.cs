/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        // 從左右兩側收斂檢查
        int left = 1, right = n;
        while (left < right) {
            int mid = left + (right - left) / 2;

            if (IsBadVersion(mid)) {
                right = mid;
            }
            else {
                left = mid + 1;
            }
        }
        return left;
    }
}