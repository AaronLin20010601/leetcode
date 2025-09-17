public class Solution {
    public bool CanWinNim(int n) {
        // 數量不為四的倍數即可獲勝
        return !(n % 4 == 0);
    }
}