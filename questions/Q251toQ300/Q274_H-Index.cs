public class Solution {
    public int HIndex(int[] citations) {
        // 將數值由大到小排列
        Array.Sort(citations, (a, b) => b.CompareTo(a));
        int hIndex = 0;

        // 從大到小數值大於等於陣列位置值即為符合條件
        for (int i = 0; i < citations.Length; i++) {
            if (citations[i] >= i + 1) {
                hIndex = i + 1;
            }
            else {
                break;
            }
        }
        return hIndex;
    }
}