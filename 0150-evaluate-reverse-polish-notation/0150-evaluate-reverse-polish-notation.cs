public class Solution {
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();

        var op = new Dictionary<string, Func<int, int, int>>()
        {
            ["+"] = (a, b) => b + a,
            ["-"] = (a, b) => b - a,
            ["*"] = (a, b) => b * a,
            ["/"] = (a, b) => b / a,
        };

        foreach (var t in tokens)
        {
            if (!int.TryParse(t, out var num))
            {
                num = op[t](stack.Pop(), stack.Pop());
            }

            stack.Push(num);
        }

        return stack.First();
    }
}