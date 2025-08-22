public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        int shift = 0;
        // 右移直到兩數位元有 1 部分相同
        while (left < right) {
            left >>= 1;
            right >>= 1;
            shift++;
        }
        return left << shift;
    }
}