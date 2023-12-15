public class Solution {
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length;

        var sl = new Dictionary<int, int>();

        int end = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            if ((n - i - 1) % 2 == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    sl[++end] = board[i][j];
                }
            }
            else
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    sl[++end] = board[i][j];
                }
            }
        }

        var que = new Queue<int>();

        que.Enqueue(1);

        var vis = new HashSet<int>() { 1 };

        int dist = 0;

        while (que.Count > 0)
        {
            int m = que.Count;

            while (m-- > 0)
            {
                var curr = que.Dequeue();

                if (curr == end) return dist;

                for (int next = curr + 1; next <= Math.Min(curr + 6, end); next++)
                {
                    if (sl[next] == -1 && vis.Add(next))
                    {
                        que.Enqueue(next);
                    }

                    if (sl[next] != -1 && vis.Add(sl[next]))
                    {
                        que.Enqueue(sl[next]);
                    }
                }
            }

            dist++;
        }

        return -1;
    }
}