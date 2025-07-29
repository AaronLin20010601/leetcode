public class Solution {
    public IList<int> GrayCode(int n) {
        List<int> result = new List<int> { 0 };

        for (int i = 0; i < n; i++) {
            int newBit = 1 << i;
            // 由後往前反轉並加上 graycode bit
            for (int j = result.Count - 1; j >= 0; j--) {
                result.Add(result[j] | newBit);
            }
        }
        return result;
    }
}