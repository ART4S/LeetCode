public class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        return MaxSubarraySumCircular_KA(nums);
    }

    // n
    private int MaxSubarraySumCircular_KA(int[] nums)
    {
        int totalSum = 0;
        int smin = 0;
        int minSum = int.MaxValue;
        int smax = 0;
        int maxSum = int.MinValue;

        foreach (var num in nums)
        {
            totalSum += num;

            smin += num;
            smax += num;

            minSum = Math.Min(minSum, smin);
            maxSum = Math.Max(maxSum, smax);

            smin = Math.Min(smin, 0);
            smax = Math.Max(smax, 0);
        }

        int a = totalSum - minSum;
        int b = maxSum;

        if (a == 0 && b < 0)
        {
            return b;
        }

        return Math.Max(a, b);
    }

    // n^2 TLE
    private int MaxSubarraySumCircular_Queue(int[] nums)
    {
        int n = nums.Length;

        int maxSum = int.MinValue;

        var que = new Queue<int[]>();

        for (int i = 0, j = 0; i < 2 * n; i++, j = (j + 1) % n)
        {
            int m = que.Count;

            while (m-- > 0)
            {
                var cur = que.Dequeue();

                int sum = cur[0];
                int len = cur[1];

                if (len > n) continue;

                maxSum = Math.Max(maxSum, sum);

                if (sum < 0) continue;

                cur[0] += nums[j];
                cur[1]++;

                que.Enqueue(cur);
            }

            que.Enqueue(new []{ nums[j], 1 });
        }

        return maxSum;
    }
}