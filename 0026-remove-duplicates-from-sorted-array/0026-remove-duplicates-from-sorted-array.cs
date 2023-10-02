public class Solution {
    public int RemoveDuplicates(int[] nums)
    {
        int k = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int j = i;
            while (j + 1 < nums.Length && nums[j + 1] == nums[i])
            {
                j++;
            }
            nums[k] = nums[i];
            k++;
            i = j;
        }

        return k;
    }
}