public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        return MinSubArrayLen_TwoPointers(target, nums);
    }

    private int MinSubArrayLen_TwoPointers(int target, int[] nums)
    {
        int minLen = int.MaxValue;

        for (int l = 0, r = 0, sum = 0; r < nums.Length; r++)
        {
            sum += nums[r];

            while (sum >= target)
            {
                minLen = Math.Min(minLen, r - l + 1);

                sum -= nums[l++];
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }

    private int MinSubArrayLen_BinSearch(int target, int[] nums)
    {
        int minLen = int.MaxValue;

        var sums = new int[nums.Length + 1];

        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            sums[i] = sum;

            if (sum >= target)
            {
                int l = 0;
                int r = i;

                while (l < r)
                {
                    int m = l + (r - l) / 2 + 1;

                    int s = sum - (m == 0 ? 0 : sums[m - 1]); // sum from m to i

                    if (s >= target)
                        l = m;
                    else
                        r = m - 1;
                }

                minLen = Math.Min(minLen, i - r + 1);
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}