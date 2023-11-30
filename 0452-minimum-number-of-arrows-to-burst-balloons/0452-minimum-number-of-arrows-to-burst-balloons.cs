public class Solution {
    public int FindMinArrowShots(int[][] points)
    {
        var events = new List<int[]>();

        for (int i = 0; i < points.Length; i++)
        {
            events.Add(new []{ points[i][0], 0, i}); // open
            events.Add(new []{ points[i][1], 1, i}); // close
        }

        events.Sort((x, y) =>
        {
            if (x[0] == y[0])
            {
                if (x[1] == y[1])
                {
                    return 0;
                }

                return x[1] > y[1] ? 1 : -1;
            }

            return x[0] > y[0] ? 1 : -1;
        });

        int res = 0;

        var open = new HashSet<int>();

        foreach (var e in events)
        {
            if (e[1] == 0)
                open.Add(e[2]);
            else if (open.Contains(e[2]))
            {
                open.Clear();
                res++;
            }
        }

        return res;
    }
}