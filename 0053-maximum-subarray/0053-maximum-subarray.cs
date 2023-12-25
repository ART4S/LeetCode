public class Solution {
    public int MaxSubArray(int[] nums)
    {
        return MaxSubArray_DP(nums);
    }

    // n
    private int MaxSubArray_DP(int[] nums)
    {
        int sum = 0;
        int maxSum = int.MinValue;

        foreach (var num in nums)
        {
            sum += num;
            maxSum = Math.Max(maxSum, sum);
            sum = Math.Max(sum, 0);
        }

        return maxSum;
    }

    // n logn TLE
    private int MaxSubArray_DaQ(int[] nums)
    {
        return daq(nums, 0, nums.Length - 1);

        int daq(int[] nums, int l, int r)
        {
            if (l == r) return nums[l];

            int m = l + (r - l) / 2;

            int lsum = 0;
            int maxlsum = int.MinValue;

            for (int i = m; i >= 0; i--)
            {
                lsum += nums[i];
                maxlsum = Math.Max(lsum, maxlsum);
            }

            int rsum = 0;
            int maxrsum = int.MinValue;

            for (int i = m + 1; i <= r; i++)
            {
                rsum += nums[i];
                maxrsum = Math.Max(rsum, maxrsum);
            }

            return Math.Max(
                Math.Max(
                    daq(nums, l, m), 
                    daq(nums, m + 1, r)), 
                maxlsum + maxrsum);
        }
    }
}