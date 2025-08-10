public class Solution {
    public int Candy(int[] ratings) {
        int people = ratings.Length;
        if (people == 0) {
            return 0;
        }
        if (people == 1) {
            return 1;
        }

        int[] candies = new int[people];
        // 每人最少會有一顆
        for (int i = 0; i < people; i++) {
            candies[i] = 1;
        }
        // 從左到右檢查,確保左邊分數較高時糖果數也較多
        for (int i = 1; i < people; i++) {
            if (ratings[i] > ratings[i - 1]) {
                candies[i] = candies[i - 1] + 1;
            }
        }

        int total = candies[people - 1];
        // 從右到左檢查,確保右邊分數較高時糖果數也較多
        for (int i = people - 2; i >= 0; i--) {
            if (ratings[i] > ratings[i + 1]) {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
            total += candies[i];
        }
        return total;
    }
}