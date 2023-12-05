public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        return FindMinHeightTrees_MedianOfTheLongestPath(n, edges);
    }

    // n
    private IList<int> FindMinHeightTrees_MedianOfTheLongestPath(int n, int[][] edges)
    {
        var adjList = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            if (!adjList.TryGetValue(edge[0], out var e0))
            {
                e0 = new List<int>();

                adjList[edge[0]] = e0;
            }

            if (!adjList.TryGetValue(edge[1], out var e1))
            {
                e1 = new List<int>();

                adjList[edge[1]] = e1;
            }

            e0.Add(edge[1]);
            e1.Add(edge[0]);
        }

        var deepestPoint = FindDeepestPoint(adjList);

        var path = FindLongestPath(deepestPoint, adjList);

        if (path.Count % 2 == 0)
        {
            return new[] { path[path.Count / 2], path[path.Count / 2 - 1] };
        }

        return new[] { path[path.Count / 2] };
    }

    private int FindDeepestPoint(Dictionary<int, List<int>> adjList)
    {
        var que = new Queue<int>();

        int cur = 0;

        var visited = new HashSet<int> { cur };

        que.Enqueue(cur);

        while (que.Count > 0)
        {
            cur = que.Dequeue();

            if (adjList.TryGetValue(cur, out var adj))
            {
                foreach (var next in adj)
                {
                    if (visited.Add(next))
                    {
                        que.Enqueue(next);
                    }
                }
            }
        }

        return cur;
    }

    private List<int> FindLongestPath(int start, Dictionary<int, List<int>> adjList)
    {
        List<int> longestPath = null!;

        int maxDepth = findMaxDepth(start, new HashSet<int>() { start });

        dfs(start, 1, new List<int>(){ start }, new HashSet<int>() { start });

        return longestPath;

        bool dfs(int cur, int depth, List<int> path, HashSet<int> vis)
        {
            if (depth == maxDepth)
            {
                longestPath = path;

                return true;
            }

            if (adjList.TryGetValue(cur, out var adj))
            {
                foreach (var next in adj)
                {
                    if (vis.Add(next))
                    {
                        path.Add(next);

                        if (dfs(next, depth + 1, path, vis)) return true;

                        path.RemoveAt(path.Count - 1);
                    }
                }
            }

            return false;
        }

        int findMaxDepth(int cur, HashSet<int> vis)
        {
            int maxDepth = 0;

            if (adjList.TryGetValue(cur, out var adj))
            {
                foreach (var next in adj)
                {
                    if (vis.Add(next))
                    {
                        maxDepth = Math.Max(maxDepth, findMaxDepth(next, vis));
                    }
                }
            }

            return 1 + maxDepth;
        }
    }

    // n2 - TLE
    private IList<int> FindMinHeightTrees_BFS(int n, int[][] edges)
    {
        var adjList = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            if (!adjList.TryGetValue(edge[0], out var e0))
            {
                e0 = new List<int>();

                adjList[edge[0]] = e0;
            }

            if (!adjList.TryGetValue(edge[1], out var e1))
            {
                e1 = new List<int>();

                adjList[edge[1]] = e1;
            }

            e0.Add(edge[1]);
            e1.Add(edge[0]);
        }

        int min = int.MaxValue;
        var res = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int maxDepth = getMaxDepth(i);

            if (maxDepth > min) continue;

            if (maxDepth < min)
            {
                min = maxDepth;
                res.Clear();
            }

            res.Add(i);
        }

        return res;

        int getMaxDepth(int v)
        {
            var visited = new HashSet<int>();

            var que = new Queue<int>();

            que.Enqueue(v);

            visited.Add(v);

            int depth = 0;

            while (que.Count > 0)
            {
                int n = que.Count;

                depth++;

                while (n-- > 0)
                {
                    if (adjList.TryGetValue(que.Dequeue(), out var adj))
                    {
                        foreach (var next in adj)
                        {
                            if (visited.Add(next))
                            {
                                que.Enqueue(next);
                            }
                        }
                    }
                }
            }

            return depth;
        }
    }

    // n3 - TLE
    private IList<int> FindMinHeightTrees_Floyd(int n, int[][] edges)
    {
        const int inf = (int)1e9;

        var dist = new int[n][];

        for (int i = 0; i < n; i++)
        {
            dist[i] = new int[n];

            for (int j = 0; j < n; j++)
            {
                dist[i][j] = inf;
            }
        }

        foreach (var edge in edges)
        {
            dist[edge[0]][edge[1]] = 1;
            dist[edge[1]][edge[0]] = 1;
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }

        int min = inf;

        var res = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int max = 0;

            for (int j = 0; j < n; j++)
            {
                if (dist[i][j] < inf)
                {
                    max = Math.Max(max, dist[i][j]);
                }
            }

            if (max > min) continue;

            if (max < min)
            {
                min = max;

                res.Clear();
            }

            res.Add(i);
        }

        return res;
    }
}