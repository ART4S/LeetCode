public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        return MaxProfitAssignment_DP(difficulty, profit, worker);
    }

    // max(d, w)
    private int MaxProfitAssignment_DP(int[] difficulty, int[] profit, int[] worker)
    {
        int n = worker.Length;
        int m = difficulty.Length;

        int maxd = Math.Max(worker.Max(), difficulty.Max());

        var dp = new int[maxd + 1];

        for (int i = 0; i < m; i++)
        {
            dp[difficulty[i]] = Math.Max(dp[difficulty[i]], profit[i]);
        }

        for(int i = 1; i < dp.Length; i++)
        {
            dp[i] = Math.Max(dp[i], dp[i - 1]);
        }

        int res = 0;

        for (int i = 0; i < n; i++)
        {
            res += dp[worker[i]];
        }

        return res;
    }

    // n logn + m logm
    private int MaxProfitAssignment_Sort(int[] difficulty, int[] profit, int[] worker)
    {
        int n = worker.Length;
        int m = difficulty.Length;

        var jobs = new int[m][];

        for (int ii = 0; ii < m; ii++)
        {
            jobs[ii] = new[] { difficulty[ii], profit[ii] };
        }

        Array.Sort(jobs, (a, b) => a[0] - b[0]);

        Array.Sort(worker);

        int res = 0;

        int i = 0;
        int j = 0;
        int maxp = 0;

        while (i < n && j < m)
        {
            int workerd = worker[i];
            int jobd = jobs[j][0];
            int jobp = jobs[j][1];

            if (jobd > workerd)
            {
                res += maxp;
                i++;
            }
            else
            {
                maxp = Math.Max(maxp, jobp);
                j++;
            }
        }

        while (i++ < n)
        {
            res += maxp;
        }

        return res;
    }

    // n m
    private int MaxProfitAssignment_BruteForce(int[] difficulty, int[] profit, int[] worker)
    {
        int n = worker.Length;
        int m = difficulty.Length;

        int res = 0;

        for (int i = 0; i < n; i++)
        {
            int maxProfit = 0;

            for (int j = 0; j < m; j++)
            {
                if (difficulty[j] <= worker[i])
                {
                    maxProfit = Math.Max(maxProfit, profit[j]);
                }
            }

            res += maxProfit;
        }

        return res;
    }
}