public class Solution {
    public int FirstMissingPositive(int[] nums) {
        for (int i = 0; i < nums.Length; i++)
        {
            while (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1])
            {
                (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] - 1 == i)
            {
                continue;
            }

            return i + 1;
        }

        return nums.Length + 1;
    }
}