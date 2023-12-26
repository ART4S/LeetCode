public class Solution {
    public string FindLongestWord(string s, IList<string> dictionary)
    {
        return FindLongestWord_TwoPointers(s, dictionary);
    }

    private string FindLongestWord_TwoPointers(string s, IList<string> dictionary)
    {
        var dict = new HashSet<string>(dictionary);

        string res = "";

        foreach (var word in dict)
        {
            if ((word.Length > res.Length || word.Length == res.Length && string.CompareOrdinal(word, res) < 0) && check(s, word))
            {
                res = word;
            }
        }

        return res;

        bool check(string from, string to)
        {
            int fl = 0;
            int fr = from.Length - 1;
            int tl = 0;
            int tr = to.Length - 1;

            while (fl <= fr && tl <= tr)
            {
                if (from[fl] == to[tl])
                {
                    fl++;
                    tl++;
                }
                else
                {
                    fl++;
                }

                if (from[fr] == to[tr])
                {
                    fr--;
                    tr--;
                }
                else
                {
                    fr--;
                }
            }

            return tl > tr;
        }
    }

    private string FindLongestWord_DP(string s, IList<string> dictionary)
    {
        var dict = new HashSet<string>(dictionary);

        string res = "";

        foreach (var word in dict)
        {
            if ((word.Length > res.Length || word.Length == res.Length && string.CompareOrdinal(word, res) < 0) && check(s, word))
            {
                res = word;
            }
        }

        return res;

        bool check(string from, string to)
        {
            int n = to.Length;
            int m = from.Length;

            var dp = new bool[n + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[m + 1];

                for(int j = 0; j < dp[i].Length; j++)
                {
                    dp[0][j] = true;
                }
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (to[i - 1] == from[j - 1])
                        dp[i][j] = dp[i][j] || dp[i - 1][j - 1] || dp[i][j - 1];
                    else
                        dp[i][j] = dp[i][j] || dp[i][j - 1];
                }
            }

            for (int j = 0; j <= m; j++)
            {
                if (dp[n][j])
                {
                    return true;
                }
            }

            return false;
        }
    }
}