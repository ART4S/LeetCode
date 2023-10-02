public class Solution {
    public int[] ProductExceptSelf(int[] nums)
    {
        var res = new int[nums.Length];

        for (int i = 0, j = 1; i < nums.Length; j *= nums[i++])
        {
            res[i] = j;
        }

        for (int i = nums.Length - 1, j = 1; i >= 0; j *= nums[i--])
        {
            res[i] *= j;
        }

        return res;
    }
}