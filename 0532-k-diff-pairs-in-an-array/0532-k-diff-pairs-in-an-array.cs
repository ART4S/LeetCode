public class Solution {
    public int FindPairs(int[] nums, int k)
    {
        return FindPairs_HashSet(nums, k);
    }

    // n
    private int FindPairs_HashSet(int[] nums, int k)
    {
        // |a - b| = k
        // a - b = k => a = b + k
        // a - b = -k => a = b - k

        var set = new HashSet<int>();
        var vis = new HashSet<(int, int)>();

        foreach (var num in nums)
        {
            int a = num;
            int b = a + k;

            if (set.Contains(b))
            {
                if (a > b) (a, b) = (b, a);

                vis.Add((a, b));
            }

            a = num;
            b = a - k;

            if (set.Contains(b))
            {
                if (a > b) (a, b) = (b, a);

                vis.Add((a, b));
            }

            set.Add(num);
        }

        return vis.Count;
    }

    // n^2
    private int FindPairs_Sort(int[] nums, int k) 
    {
        int n = nums.Length;

        Array.Sort(nums);

        int res = 0;

        for(int i = 0; i < n - 1; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for(int j = i + 1; j < n; j++)
            {
                if (j > i + 1 && nums[j] == nums[i + 1]) continue;
                
                int ijmod = Math.Abs(nums[i] - nums[j]);
                int jimod = Math.Abs(nums[j] - nums[i]);

                if (ijmod == jimod && ijmod == k) res++;
            }
        }  

        return res;
    }
}