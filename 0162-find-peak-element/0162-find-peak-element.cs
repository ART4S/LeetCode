public class Solution {
    public int FindPeakElement(int[] nums)
    {
        return FindPeakElement_ExactBinSearch(nums);
    }

    private int FindPeakElement_ExactBinSearch(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int m = l + (r - l) / 2;

            long left = m == 0 ? long.MinValue : nums[m - 1];
            long right = m == nums.Length - 1 ? long.MinValue : nums[m + 1];

            if (left < nums[m] && nums[m] > right)
            {
                return m;
            }

            if (left < nums[m])
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return -1;
    }

    private int FindPeakElement_LeftBinSearch(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l < r)
        {
            int m = l + (r - l) / 2;

            long right = m == nums.Length - 1 ? long.MaxValue : nums[m + 1];

            if (nums[m] < right)
                l = m + 1;
            else
                r = m;
        }

        return l;
    }

    private int FindPeakElement_RightBinSearch(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l < r)
        {
            int m = l + (r - l) / 2 + 1;

            long left = m == 0 ? long.MaxValue : nums[m - 1];

            if (left < nums[m])
                l = m;
            else
                r = m - 1;
        }

        return r;
    }
}