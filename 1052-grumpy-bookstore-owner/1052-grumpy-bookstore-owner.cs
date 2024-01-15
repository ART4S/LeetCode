public class Solution {
    // n
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        var n = customers.Length;
        var right_sum = new int[n];
        var left_sum = new int[n];

        for (int i = 1, j = n - 2; i < n; i++, j--)
        {
            left_sum[i] = left_sum[i - 1];

            if (grumpy[i - 1] == 0)
            {
                left_sum[i] += customers[i - 1];
            }

            right_sum[j] = right_sum[j + 1];

            if (grumpy[j + 1] == 0)
            {
                right_sum[j] += customers[j + 1];
            }
        }

        int max_satisfied = 0;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += customers[i];

            if (i >= minutes)
            {
                sum -= customers[i - minutes];
            }

            if (i >= minutes - 1)
            {
                max_satisfied = Math.Max(max_satisfied, sum + left_sum[i - minutes + 1] + right_sum[i]);
            }
        }

        return max_satisfied;
    }
}