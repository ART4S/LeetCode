public class Solution {
    public int LargestRectangleArea(int[] heights)
    {
        int maxArea = 0;

        var stack = new Stack<int[]>();

        int w;

        foreach (var h in heights)
        {
            w = 0;

            while (stack.TryPeek(out var peek) && peek[0] >= h)
            {
                stack.Pop();

                w += peek[1];

                maxArea = Math.Max(maxArea, peek[0] * w);
            }

            stack.Push(new []{ h, w + 1 });
        }

        w = 0;

        while (stack.TryPop(out var pop))
        {
            w += pop[1];

            maxArea = Math.Max(maxArea, pop[0] * w);
        }

        return maxArea;
    }
}