public class Solution
{
    public int LongestSubstring(string s, int k)
    {
        return LongestSubstring_SlidingWindow(s, k);
    }

    // n
    private int LongestSubstring_SlidingWindow(string s, int k)
    {
        int len = 0;

        for (int max_unique = 1; max_unique <= 26; max_unique++)
        {
            int l = 0;
            int r = 0;
            var count = new int[26];
            int count_k = 0;
            int count_unique = 0;

            while (r < s.Length)
            {
                int c;

                if (count_unique <= max_unique)
                {
                    c = ++count[s[r++] - 'a'];

                    if (c == 1)
                    {
                        count_unique++;
                    }

                    if (c == k)
                    {
                        count_k++;
                    }
                }
                else
                {
                    c = --count[s[l++] - 'a'];

                    if (c == 0)
                    {
                        count_unique--;
                    }

                    if (c == k - 1)
                    {
                        count_k--;
                    }
                }

                if (count_k == count_unique)
                {
                    len = Math.Max(len, r - l);
                }
            }
        }

        return len;
    }

    // n^2
    private int LongestSubstring_BruteForce_Modified(string s, int k)
    {
        for (int window_len = s.Length; window_len >= k; window_len--)
        {
            var count = new int[26];
            var count_k = 0;
            var count_unique = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int c = ++count[s[i] - 'a'];

                if (c == 1)
                {
                    count_unique++;
                }

                if (c == k)
                {
                    count_k++;
                }

                if (i >= window_len)
                {
                    c = --count[s[i - window_len] - 'a'];

                    if (c == k - 1)
                    {
                        count_k--;
                    }

                    if (c == 0)
                    {
                        count_unique--;
                    }
                }

                if (i >= window_len - 1 && count_k == count_unique)
                {
                    return window_len;
                }
            }
        }

        return 0;
    }

    // n^2
    private int LongestSubstring_BruteForce(string s, int k)
    {
        int len = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var count = new int[26];
            int count_k = 0;
            int count_unique = 0;

            for (int j = i; j < s.Length; j++)
            {
                int c = ++count[s[j] - 'a'];

                if (c == 1)
                {
                    count_unique++;
                }

                if (c == k)
                {
                    count_k++;
                }

                if (count_k == count_unique)
                {
                    len = Math.Max(len, j - i + 1);
                }
            }
        }

        return len;
    }
}