public class Solution {
    public int KthSmallest(int[][] matrix, int k)
    {
        int n = matrix.Length;

        var visited = new bool[n, n];
        
        var que = new PriorityQueue<int[], int>();

        var cell = new []{0, 0};

        que.Enqueue(cell, matrix[0][0]);

        visited[0, 0] = true;

        var di = new [] { 0, 1 };
        var dj = new [] { 1, 0 };

        while (k-- > 0)
        {
            cell = que.Dequeue();

            for (int i = 0; i < 2; i++)
            {
                var ncell = new[] { cell[0] + di[i], cell[1] + dj[i] };

                if (ncell[0] < n && ncell[1] < n && !visited[ncell[0], ncell[1]])
                {
                    visited[ncell[0], ncell[1]] = true;

                    que.Enqueue(ncell, matrix[ncell[0]][ncell[1]]);
                }
            }    
        }

        return matrix[cell[0]][cell[1]];
    }
}