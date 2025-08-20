public class Solution {
    public int ReverseBits(int n) {
        uint result = 0;
        uint num = (uint)n;

        // 逐位元從 num 的最低位元往結果尾端推進
        for (int i = 0; i < 32; i++) {
            result = (result << 1) | (num & 1);
            num >>= 1;
        }
        return (int)result;
    }
}