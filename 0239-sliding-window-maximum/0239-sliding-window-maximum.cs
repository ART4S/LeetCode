public class Solution {
    // n log k
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var n = nums.Length;
        var res = new int[n - k + 1];
        var pq = new PriorityQueue<int, int>();

        for (int i = 0, j = 0; i < n; i++)
        {
            pq.Enqueue(i, -nums[i]);

            if (i >= k - 1)
            {
                int ind;

                while (pq.TryPeek(out ind, out _) && ind <= i - k)
                {
                    pq.Dequeue();
                }

                res[j++] = nums[ind];
            }
        }

        return res;
    }
}