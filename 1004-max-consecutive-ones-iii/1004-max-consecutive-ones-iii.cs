public class Solution {
    public int LongestOnes(int[] nums, int k)
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
}