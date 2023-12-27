public class Solution {
    public int NumSubarrayBoundedMax(int[] nums, int left, int right)
    {
        int res = 0;

        for (int i = 0, j = -1, k = -1; i < nums.Length; i++)
        {
            if (nums[i] < left)
            {
                if (k != -1)
                {
                    res += k - j;
                }
            }
            else if (nums[i] > right)
            {
                j = i;

                k = -1;
            }
            else
            {
                k = i;

                res += k - j;
            }
        }

        return res;
    }
}