public class Solution {
    public int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int m = l + (r - l) / 2;

            if (nums[l] == target) return l;
            if (nums[r] == target) return r;
            if (nums[m] == target) return m;

            if (nums[m] > nums[l] && target > nums[l] || nums[m] < nums[r] && target < nums[r])
            {
                if (nums[m] > target)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            else if (nums[m] > nums[l])
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
}