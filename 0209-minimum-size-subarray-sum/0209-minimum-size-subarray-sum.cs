public class Solution {
    public int MinSubArrayLen(int target, int[] nums)
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
}