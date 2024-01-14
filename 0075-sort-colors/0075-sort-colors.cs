public class Solution
{
    // n
    public void SortColors(int[] nums)
    {
        int n = nums.Length;
        int i = 0;
        int l = 0;
        int r = n - 1;

        while (i <= r)
        {
            switch (nums[i])
            {
                case 0:
                    (nums[i], nums[l]) = (nums[l], nums[i]);
                    l++;
                    i++;
                    break;
                case 1:
                    i++;
                    break;
                case 2:
                    (nums[i], nums[r]) = (nums[r], nums[i]);
                    r--;
                    break;
            }
        }
    }
}