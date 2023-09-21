public class Solution {
    public bool IsValid(string s)
    {
        var open = new[] { '(', '{', '[' };

        var close = new Dictionary<char, char>()
        {
            ['('] = ')',
            ['{'] = '}',
            ['['] = ']',
        };

        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (open.Contains(c))
            {
                stack.Push(c);
            }
            else if (stack.Count is 0 || c != close[stack.Pop()])
            {
                return false;
            }
        }

        return stack.Count is 0;
    }
}