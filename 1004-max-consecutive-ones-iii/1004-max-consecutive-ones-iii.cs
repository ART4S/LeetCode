public class Solution {
    public int LongestOnes(int[] nums, int k)
    {
        return LongestOnes_SlidingWindow(nums, k);
    }

    private int LongestOnes_SlidingWindow(int[] nums, int k)
    {
        int max = 0;
        int z = 0;

        for (int l = 0, r = 0; r < nums.Length; r++)
        {
            if (nums[r] == 0)
            {
                z++;
            }

            while (z > k)
            {
                if (nums[l++] == 0)
                {
                    z--;
                }
            }

            max = Math.Max(max, r - l + 1);
        }

        return max;
    }

    private int LongestOnes_PrefixSum(int[] nums, int k)
    {
        var ps = new int[nums.Length];

        int sum = 0;
        int max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += 1 - nums[i];

            ps[i] += sum;

            int l = 0;
            int r = i;

            while (l < r)
            {
                int m = l + (r - l) / 2;

                if (ps[i] - (m > 0 ? ps[m - 1] : 0) > k)
                    l = m + 1;
                else
                    r = m;
            }

            if (ps[i] - (l > 0 ? ps[l - 1] : 0) <= k)
            {
                max = Math.Max(max, i - l + 1);
            }
        }

        return max;
    }
}