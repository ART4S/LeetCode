public class Solution {
    public bool IsAnagram(string s, string t)
    {
        var map = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (!map.TryAdd(c, 1))
            {
                map[c]++;
            }
        }

        int coundown = map.Count;

        foreach (var c in t)
        {
            if (!map.TryGetValue(c, out var cnt) || cnt is 0)
            {
                return false;
            }

            if (cnt is 1)
            {
                coundown--;
            }

            map[c]--;
        }

        return coundown == 0;
    }
}