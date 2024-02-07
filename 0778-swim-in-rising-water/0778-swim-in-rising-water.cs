public class Solution {
    public int SwimInWater(int[][] grid)
    {
        var n = grid.Length;
        var t = 0;
        var vis = new bool[n, n];
        var que = new PriorityQueue<(int, int), int>();
        var di = new[] { 1, -1, 0, 0 };
        var dj = new[] { 0, 0, 1, -1 };

        que.Enqueue((0, 0), grid[0][0]);

        vis[0, 0] = true;

        while (que.TryDequeue(out var item, out _))
        {
            var (i, j) = item;

            t = Math.Max(t, grid[i][j]);

            if (i == n - 1 && j == n - 1) return t;

            for (int d = 0; d < 4; d++)
            {
                var ni = i + di[d];
                var nj = j + dj[d];

                if (ni >= 0 && ni < n && nj >= 0 && nj < n && !vis[ni, nj])
                {
                    que.Enqueue((ni, nj), grid[ni][nj]);

                    vis[ni, nj] = true;
                }
            }
        }

        return t;
    }
}