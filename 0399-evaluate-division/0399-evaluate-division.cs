public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var adjList = new Dictionary<string, Dictionary<string, double>>();

        for (int i = 0; i < equations.Count; i++)
        {
            if (!adjList.TryGetValue(equations[i][0], out var e0))
            {
                e0 = new Dictionary<string, double>();
                adjList.Add(equations[i][0], e0);
            }

            if (!adjList.TryGetValue(equations[i][1], out var e1))
            {
                e1 = new Dictionary<string, double>();
                adjList.Add(equations[i][1], e1);
            }

            e0[equations[i][1]] = values[i];
            e1[equations[i][0]] = 1 / values[i];
        }

        var res = new double[queries.Count];

        for (int i = 0; i < queries.Count; i++)
        {
            res[i] = bfs(queries[i]);
        }

        return res;

        double bfs(IList<string> query)
        {
            if (!adjList.ContainsKey(query[0])) return -1;

            var que = new Queue<(string, double)>();

            que.Enqueue((query[0], 1));

            var vis = new HashSet<string>();

            while (que.TryDequeue(out var item))
            {
                var (cur, acc) = item;

                if (cur == query[1]) return acc;

                if (adjList.TryGetValue(cur, out var adj))
                {
                    foreach (var (next, nextacc) in adj)
                    {
                        if (vis.Add(next))
                        {
                            adjList[query[0]][next] = acc * nextacc; // union find like optimisation

                            que.Enqueue((next, acc * nextacc));
                        }
                    }
                }
            }

            return -1;
        }
    }
}