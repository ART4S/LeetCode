public class Solution {
    public string SimplifyPath(string path)
    {
        path += '/';

        var stack = new Stack<char>();

        int dot = 0;
        int sym = 0;

        foreach (var ch in path)
        {
            if (ch == '/')
            {
                if (sym == 0 && dot is 1 or 2) // command
                {
                    while (dot-- > 0 && stack.Count > 0)
                    {
                        while (stack.TryPeek(out var peek) && peek != '/')
                        {
                            stack.Pop();
                        }

                        stack.Pop();
                    }
                }

                dot = 0;
                sym = 0;

                while (stack.TryPeek(out var peek) && peek == '/')
                {
                    stack.Pop();
                }
            }
            else if (ch == '.')
            {
                dot++;
            }
            else
            {
                sym++;
            }

            stack.Push(ch);
        }

        if (stack.Count > 1) // remove last slash
        {
            stack.Pop();
        }

        var res = new char[stack.Count];

        for (int i = res.Length - 1; i >= 0; i--)
        {
            res[i] = stack.Pop();
        }

        return new string(res);
    }
}