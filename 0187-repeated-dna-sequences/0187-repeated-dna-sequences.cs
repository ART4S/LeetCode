public class Solution {
    // n
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        var vis = new HashSet<string>();
        var res = new HashSet<string>();

        for (int i = 10; i <= s.Length; i++)
        {
            var ss = s[(i - 10)..i];

            if (!vis.Add(ss))
            {
                res.Add(ss);
            }
        }

        return res.ToArray();
    }
}