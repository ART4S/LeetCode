public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k == 0) return 0;

        int res = 0;
        int product = 1;

        for (int i = 0, j = 0; i < nums.Length; i++)
        {
            product *= nums[i];

            while (product >= k && i != j)
            {
                product /= nums[j++];
            }

            if (product < k)
            {
                res += i - j + 1;
            }
        }

        return res;
    }
}