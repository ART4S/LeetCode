public class Solution {
    public int NumberOfSubarrays(int[] nums, int k)
    {
        return NumberOfSubarrays_SlidingWindow(nums, k);
    }

    // n
    private int NumberOfSubarrays_SlidingWindow(int[] nums, int k)
    {
        int n = nums.Length;
        int odd = 0;
        int even_before_window = 0;
        int res = 0;

        for (int i = 0, j = 0; i < n; i++)
        {
            if (nums[i] % 2 != 0) odd++;

            if (odd > k)
            {
                j++;
                odd--;
                even_before_window = 0;
            }

            if (odd == k)
            {
                while (j < i && nums[j] % 2 == 0)
                {
                    j++;
                    even_before_window++;
                }

                res += even_before_window + 1;
            }
        }

        return res;
    }

    // n
    private int NumberOfSubarrays_PrefSum(int[] nums, int k)
    {
        var pref_sum = new Dictionary<int, int>() { [0] = 1 };

        int odd = 0;
        int res = 0;

        foreach (var num in nums)
        {
            if (num % 2 != 0) odd++;

            pref_sum.TryAdd(odd, 0);
            pref_sum[odd]++;

            if (pref_sum.TryGetValue(odd - k, out var cnt))
            {
                res += cnt;
            }
        }

        return res;
    }
}