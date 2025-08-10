public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int gasLength = gas.Length;
        if (gasLength == 0) {
            return -1;
        }

        long gasLeft = 0, tank = 0;
        int startPoint = 0;
        for (int i = 0; i < gasLength; i++) {
            // 檢查經過該點時的油量差值和油量值
            long currentGas = (long)gas[i] - (long)cost[i];
            gasLeft += currentGas;
            tank += currentGas;

            // 油箱值小於零則該範圍無法跑完
            if (tank < 0) {
                startPoint = i + 1;
                tank = 0;
            }
        }
        return gasLeft >= 0 && startPoint < gasLength ? startPoint : -1;
    }
}