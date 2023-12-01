public class Solution {
    public bool Search(int[] nums, int target)
    {
        return BinSearch(nums, 0, nums.Length - 1, target);
    }

    private bool BinSearch(int[] nums, int l, int r, int target)
    {
        while (l <= r)
        {
            int m = l + (r - l) / 2;

            if (nums[m] == target) return true;
            if (nums[l] == target) return true;
            if (nums[r] == target) return true;

            if (nums[l] == nums[r])
            {
                return BinSearch(nums, l, m - 1, target) || BinSearch(nums, m + 1, r, target);
            }

            if (nums[m] >= nums[l] && target > nums[l] || nums[m] <= nums[r] && target < nums[r])
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
            else if (nums[m] >= nums[l])
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return false;
    }
}