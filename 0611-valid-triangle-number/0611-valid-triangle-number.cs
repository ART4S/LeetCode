public class Solution {
    public int TriangleNumber(int[] nums)
    {
        return TriangleNumber_TwoPointers(nums);
    }

    
    // n^2
    private int TriangleNumber_TwoPointers(int[] nums) 
    {
        Array.Sort(nums, (a, b) => b - a);

        int n = nums.Length;

        int res = 0;

        for (int i = 0; i < n; i++)
        {
            int l = i + 1;
            int r = n - 1;

            while (l < r)
            {
                if (nums[l] + nums[r] > nums[i])
                {
                    res += r - l;
                    l++;
                }
                else
                {
                    r--;
                }

            }
        }

        return res;
    }

    // n^2 logn
    private int TriangleNumber_BinarySearch(int[] nums) 
    {
        Array.Sort(nums);

        int n = nums.Length;

        int res = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int l = j + 1;
                int r = n - 1;

                if (l > r) break;

                int target = nums[i] + nums[j];

                while (l < r)
                {
                    int m = l + (r - l) / 2 + 1;

                    if (nums[m] < target)
                        l = m;
                    else
                        r = m - 1;
                }

                if (nums[r] < target)
                {
                    res += r - j;
                }
            }
        }

        return res;
    }

    // n^3
    private int TriangleNumber_BruteForce(int[] nums) 
    {
        int n = nums.Length;

        int res = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    int a = nums[i];
                    int b = nums[j];
                    int c = nums[k];

                    if (a > b) (a, b) = (b, a);
                    if (a > c) (a, c) = (c, a);
                    if (b > c) (b, c) = (c, b);

                    if (a + b > c)
                    {
                        res++;
                    }
                }
            }
        }

        return res;
    }
}