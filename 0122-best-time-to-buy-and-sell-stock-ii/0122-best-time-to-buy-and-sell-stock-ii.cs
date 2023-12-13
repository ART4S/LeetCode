public class Solution {
    public int MaxProfit(int[] prices) {
        int profit = 0;

        for(int i = 0; i < prices.Length - 1; i++)
        {
            profit += Math.Max(prices[i + 1] - prices[i], 0);
        }

        return profit;
    }
}