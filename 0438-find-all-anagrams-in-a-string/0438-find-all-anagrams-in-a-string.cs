public class Solution {
    // n
    public IList<int> FindAnagrams(string s, string p)
    {
        var p_count = new Dictionary<char, int>();

        foreach (var c in p)
        {
            p_count.TryAdd(c, 0);
            p_count[c]++;
        }

        int window_size = p.Length;
        int p_count_unique = p_count.Count;
        var window_count = new Dictionary<char, int>();
        var window_count_unique = 0;
        var res = new List<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (p_count.ContainsKey(s[i]))
            {
                if (--p_count[s[i]] == 0)
                {
                    p_count_unique--;
                }
            }
            else
            {
                window_count.TryAdd(s[i], 0);

                if (++window_count[s[i]] == 1)
                {
                    window_count_unique++;
                }
            }

            if (i >= window_size)
            {
                int j = i - window_size;

                if (p_count.ContainsKey(s[j]))
                {
                    if (++p_count[s[j]] == 1)
                    {
                        p_count_unique++;
                    }
                }
                else
                {
                    if (--window_count[s[j]] == 0)
                    {
                        window_count_unique--;
                    }
                }
            }

            if (p_count_unique == 0 && window_count_unique == 0)
            {
                res.Add(i - window_size + 1);
            }
        }

        return res;
    }
}