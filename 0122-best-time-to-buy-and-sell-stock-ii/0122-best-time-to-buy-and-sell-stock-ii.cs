public class Solution {
    public int MaxProfit(int[] prices)
    {
        return MaxProfit_Greedy(prices);
    }

    private int MaxProfit_Greedy(int[] prices) {
        int profit = 0;

        for(int i = 1; i < prices.Length; i++)
        {
            profit += Math.Max(prices[i] - prices[i - 1], 0);
        }

        return profit;
    }

    private int MaxProfit_DP(int[] prices)
    {
        var memo = new int[prices.Length][];

        for (int i = 0; i < memo.Length; i++)
        {
            memo[i] = new [] { -1, -1 };
        }

        return solve(0, 0);

        int solve(int i, int buy)
        {
            if (i == prices.Length) return 0;

            if (memo[i][buy] == -1)
            {
                if (buy == 0)
                {
                    memo[i][buy] = Math.Max(solve(i + 1, 1) - prices[i], solve(i + 1, 0));
                }
                else
                {
                    memo[i][buy] = Math.Max(prices[i] + solve(i + 1, 0), solve(i + 1, 1));
                }
            }

            return memo[i][buy];
        }
    }
}