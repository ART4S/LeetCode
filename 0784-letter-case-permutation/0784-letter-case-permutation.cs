public class Solution {
    public IList<string> LetterCasePermutation(string s)
    {
        return LetterCasePermutation_Queue(s);
    }

    private IList<string> LetterCasePermutation_Queue(string s)
    {
        var que = new Queue<string>();

        que.Enqueue("");

        foreach (var ch in s)
        {
            int qlen = que.Count;

            while (qlen-- > 0)
            {
                var cur = que.Dequeue();

                if (char.IsDigit(ch))
                    que.Enqueue(cur + ch);
                else
                {
                    que.Enqueue(cur + char.ToLower(ch));
                    que.Enqueue(cur + char.ToUpper(ch));
                }
            }
        }

        return que.ToArray();
    }

    private IList<string> LetterCasePermutation_Backtracking(string s)
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