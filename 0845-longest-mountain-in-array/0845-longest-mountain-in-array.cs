public class Solution {
    public int LongestMountain(int[] arr)
    {
        return LongestMountain_Peak(arr);
    }

    // n time, 1 space
    private int LongestMountain_Peak(int[] arr)
    {
        int n = arr.Length;

        int maxLen = 0;

        int len = 1;

        bool peak = false;

        for (int i = 1; i < n; i++)
        {
            if ((peak && arr[i] > arr[i - 1]) || (!peak && arr[i - 1] > arr[i]) || arr[i] == arr[i - 1])
            {
                peak = false;
                len = 1;
            }

            if (arr[i] > arr[i - 1] || (peak && arr[i - 1] > arr[i]))
            {
                len++;
            }

            if (peak)
            {
                maxLen = Math.Max(maxLen, len);
            }

            if (i > 0 && i < n - 1 && arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                peak = true;
            }
        }

        return maxLen;
    }

    // n time, n space
    private int LongestMountain_DP(int[] arr)
    {
        int n = arr.Length;

        var up = new int[n];
        var down = new int[n];

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                up[i] += up[i - 1] + 1;
            }
        }

        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] > arr[i + 1])
            {
                down[i] += down[i + 1] + 1;
            }
        }

        int maxLen = 0;

        for (int i = 0; i < n; i++)
        {
            if (up[i] > 0 && down[i] > 0)
            {
                maxLen = Math.Max(maxLen, up[i] + down[i] + 1);
            }
        }

        return maxLen < 3 ? 0 : maxLen;
    }

    // n^2 time
    private int LongestMountain_BruteForce(int[] arr)
    {
        int maxLen = 0;

        int n = arr.Length;

        for (int i = 1; i < n - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                int len = 1;

                for (int j = i - 1; j >= 0 && arr[j] < arr[j + 1]; j--)
                {
                    len++;
                }

                for (int j = i + 1; j < n && arr[j] < arr[j - 1]; j++)
                {
                    len++;
                }

                maxLen = Math.Max(maxLen, len);
            }
        }

        return maxLen;
    }
}