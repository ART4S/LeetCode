public class Solution {
    // n
    public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen) {
        return Math.Max(solve(firstLen, secondLen), solve(secondLen, firstLen));

        int solve(int flen, int slen)
        {
            int fsum = 0;
            int ssum = 0;

            int i = 0;

            while (i < flen)
            {
                fsum += nums[i++];
            }

            int j = flen;

            while (j < flen + slen)
            {
                ssum += nums[j++];
            }

            int fmaxsum = fsum;
            int smaxsum = fmaxsum + ssum;

            while (j < nums.Length)
            {
                fsum += nums[i];
                fsum -= nums[i - flen];
                fmaxsum = Math.Max(fmaxsum, fsum);

                ssum += nums[j];
                ssum -= nums[j - slen];

                smaxsum = Math.Max(smaxsum, fmaxsum + ssum);

                i++;
                j++;
            }

            return smaxsum;
        }
    }
}