public class Solution {
    public void Rotate(int[] nums, int k)
    {
        int n = nums.Length;

        k %= n;

        if (k == 0) return;

        int i = 0;
        int r = 0;

        while (r != n)
        {
            for (int j = (i + k) % n; j != i; j = (j + k) % n)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);

                r++;
            }

            r++;
            i++;
        }
    }
}
