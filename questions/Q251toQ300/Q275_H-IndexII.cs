public class Solution {
    public int HIndex(int[] citations) {
        int hIndex = 0;

        // 從大到小數值大於等於陣列位置值即為符合條件
        for (int i = 0; i < citations.Length; i++) {
            if (citations[citations.Length - i - 1] >= i + 1) {
                hIndex = i + 1;
            }
            else {
                break;
            }
        }
        return hIndex;
    }
}