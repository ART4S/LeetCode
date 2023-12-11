public class Solution {
    public int MaxUniqueSplit(string s)
    {
        var backtrack = new HashSet<string>();

        return dfs(0);

        int dfs(int i)
        {
            if (i == s.Length) return backtrack.Count;

            int max = 0;

            for (int j = i + 1; j <= s.Length; j++)
            {
                var sub = s[i..j];

                if (backtrack.Add(sub))
                {
                    max = Math.Max(max, dfs(j));

                    backtrack.Remove(sub);
                }
            }

            return max;
        }
    }
}