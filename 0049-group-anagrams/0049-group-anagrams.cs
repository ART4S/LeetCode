public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var a = GetAnagramKey(str);

            if (!map.TryGetValue(a, out var g))
            {
                g = new List<string>();

                map.Add(a, g);
            }

            g.Add(str);
        }

        var res = new List<IList<string>>();

        foreach (var g in map.Values)
        {
            res.Add(g);
        }

        return res;
    }

    private static string GetAnagramKey(string word)
    {
        var symbols = new int[26];

        foreach (var symbol in word)
        {
            symbols[symbol - 'a']++;
        }

        var res = new char[word.Length];

        for (int i = 0, j = 0; i < symbols.Length; i++)
        {
            while (symbols[i]-- > 0)
            {
                res[j++] = (char)('a' + i);
            }
        }

        return new string(res);
    }
}