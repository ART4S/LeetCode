public class Solution {
    public int ThreeSumMulti(int[] arr, int target)
    {
        return ThreeSumMulti_TwoPointers(arr, target);
    }

    // n^2
    private int ThreeSumMulti_TwoPointers(int[] arr, int target)
    {
        const int mod = (int) 1e9 + 7;

        Array.Sort(arr);

        int n = arr.Length;

        int res = 0;

        for (int i = 0; i < n - 2; i++)
        {
            int l = i + 1;
            int r = n - 1;

            int tsum = target - arr[i];

            while (l < r)
            {
                int sum = arr[l] + arr[r];

                if (sum > tsum)
                    r--;
                else if (sum < tsum)
                    l++;
                else
                {
                    int lstart = l;
                    int rstart = r;

                    while (l <= r && arr[l] == arr[lstart]) l++;
                    while (l <= r && arr[r] == arr[rstart]) r--;

                    int count;

                    if (arr[lstart] == arr[rstart])
                        count = (l - lstart) * (l - lstart - 1) / 2;
                    else
                        count = (l - lstart) * (rstart - r);

                    res = (res + count) % mod;
                }
            }
        }

        return res;
    }

    // n^2
    private int ThreeSumMulti_HashSet(int[] arr, int target)
    {
        const int mod = (int) 1e9 + 7;

        var map = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            map.TryAdd(num, 0);
            map[num]++;
        }

        var keys = map.Keys.ToArray();

        var vis = new HashSet<(int, int, int)>();

        int res = 0;

        for (int i = 0; i < map.Count; i++)
        {
            for (int j = i; j < map.Count; j++)
            {
                int a = keys[i];
                int b = keys[j];
                int c = target - a - b;

                if (!map.ContainsKey(c)) continue;

                if (a > b) (a, b) = (b, a);
                if (a > c) (a, c) = (c, a);
                if (b > c) (b, c) = (c, b);

                if (!vis.Add((a, b, c))) continue;

                int count = 0;

                if (a == b && b == c)
                {
                    // TODO: formula?

                    int m = map[a];

                    for (int k = 0; k < m - 2; k++)
                    {
                        int mm = m - k - 1;
                        count = (count + mm * (mm - 1) / 2) % mod;
                    }
                }
                else if (a == b)
                    count = map[c] * map[a] * (map[a] - 1) / 2;
                else if (a == c)
                    count = map[b] * map[a] * (map[a] - 1) / 2;
                else if (b == c)
                    count = map[a] * map[b] * (map[b] - 1) / 2;
                else
                    count = map[a] * map[b] * map[c];

                res = (res + count) % mod;
            }
        }

        return res;
    }

    // n target
    private int ThreeSumMulti_DP(int[] arr, int target)
    {
        const int mod = (int) 1e9 + 7;

        int n = arr.Length;

        var memo = new int[n][][];

        for (int i = 0; i < n; i++)
        {
            memo[i] = new int[target + 1][];

            for (int j = 0; j <= target; j++)
            {
                memo[i][j] = new[]{ -1, -1, -1 };
            }
        }

        return dp(0, 0, 0);

        int dp(int i, int sum, int count)
        {
            if (count == 3) return sum == target ? 1 : 0;

            if (i == n || sum > target) return 0;

            if (memo[i][sum][count] == -1)
            {
                memo[i][sum][count] = (dp(i + 1, sum + arr[i], count + 1) + dp(i + 1, sum, count)) % mod;
            }

            return memo[i][sum][count];
        }
    }

    // n^3
    private int ThreeSumMulti_BruteForce(int[] arr, int target)
    {
        const int mod = (int) 1e9 + 7;

        int n = arr.Length;

        int res = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    int sum = arr[i] + arr[j] + arr[k];

                    if (sum == target)
                    {
                        res = (res + 1) % mod;
                    }
                }
            }
        }

        return res;
    }
}