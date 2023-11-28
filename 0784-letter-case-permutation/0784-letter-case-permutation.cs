public class Solution {
    public IList<string> LetterCasePermutation(string s)
    {
        var res = new List<string>();

        var backtrack = new List<char>();

        dfs(0);

        return res;

        void dfs(int i)
        {
            if (i == s.Length)
            {
                res.Add(new string(backtrack.ToArray()));
                return;
            }

            backtrack.Add(s[i]);
            dfs(i + 1);
            backtrack.RemoveAt(backtrack.Count - 1);

            if (char.IsLetter(s[i]))
            {
                char newch = char.IsUpper(s[i]) ? char.ToLower(s[i]) : char.ToUpper(s[i]);

                backtrack.Add(newch);
                dfs(i + 1);
                backtrack.RemoveAt(backtrack.Count - 1);
            }
        }
    }
}
