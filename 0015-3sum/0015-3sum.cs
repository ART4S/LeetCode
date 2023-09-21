public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        var res = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            int l = i + 1;
            int r = nums.Length - 1;

            while (l < r)
            {
                int sum = nums[l] + nums[r] + nums[i];

                if (sum == 0)
                {
                    var triplet = new[] { nums[l], nums[i], nums[r] };

                    res.Add(triplet);

                    while (l < i && nums[l] == triplet[0]) l++;
                    while (i < r && nums[r] == triplet[2]) r--;
                }
                else if (sum < 0)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }

            while (i + 1 < nums.Length - 1 && nums[i + 1] == nums[i])  i++;
        }

        return res;
    }
}