public class Solution
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        return FindLength_DP(nums1, nums2);
    }

    // n * m
    private int FindLength_DP(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int m = nums2.Length;
        int res = 0;

        var memo = new int[n][];

        for (int i = 0; i < n; i++)
        {
            memo[i] = new int[m];

            for (int j = 0; j < m; j++)
            {
                memo[i][j] = -1;
            }
        }

        dp(0, 0);

        return res;

        int dp(int i, int j)
        {
            if (i == n || j == m) return 0;

            if (memo[i][j] == -1)
            {
                int equals = 0;

                if (nums1[i] == nums2[j])
                {
                    equals = 1 + dp(i + 1, j + 1);
                }

                dp(i, j + 1);
                dp(i + 1, j);

                res = Math.Max(res, equals);

                memo[i][j] = equals;
            }

            return memo[i][j];
        }
    }

    // n * m * min(n, m)
    private int FindLength_BruteForce(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int m = nums2.Length;
        int max_len = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int ii = i;
                int jj = j;
                int len = 0;

                while (ii < n && jj < m)
                {
                    if (nums1[ii++] == nums2[jj++]) len++;
                    else break;
                }

                max_len = Math.Max(max_len, len);
            }
        }

        return max_len;
    }
}