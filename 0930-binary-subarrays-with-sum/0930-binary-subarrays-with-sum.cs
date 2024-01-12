public class Solution {
    // n
    public int NumSubarraysWithSum(int[] nums, int goal) {
        int res = 0;
        int sum = 0;
        int zeroes = 0;

        for(int i = 0, j = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            if (sum > goal)
            {
                zeroes = 0;

                while(j < i && sum > goal)
                {
                    sum -= nums[j++];
                }
            }

            while (j < i && sum == goal && nums[j] == 0)
            {
                j++;
                zeroes++;
            }

            if (sum == goal)
            {
                res += zeroes + 1;
            }
        }

        return res;
    }
}