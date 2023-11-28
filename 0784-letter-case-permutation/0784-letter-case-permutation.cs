public class Solution {
    public IList<string> LetterCasePermutation(string s)
    {
        var res = new List<string>();

        var bt = s.ToCharArray();

        dfs(0);

        return res;

        void dfs(int i)
        {
            if (i == bt.Length)
            {
                res.Add(new string(bt));
                return;
            }

            if (char.IsDigit(bt[i]))
            {
                dfs(i + 1);
                return;
            }

            bt[i] = char.ToLower(bt[i]);

            dfs(i + 1);

            bt[i] = char.ToUpper(bt[i]);

            dfs(i + 1);
        }
    }
}