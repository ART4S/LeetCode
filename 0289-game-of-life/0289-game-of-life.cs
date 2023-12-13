public class Solution {
    public void GameOfLife(int[][] board)
    {
        GameOfLife_Bit(board);
    }

    private void GameOfLife_Bit(int[][] board)
    {
        int n = board.Length;
        int m = board[0].Length;

        int[] di = { 0, 0, 1, -1, 1, 1, -1, -1 };
        int[] dj = { 1, -1, 0, 0, 1, -1, 1, -1 };

        const int dead = 0;
        const int live = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int liveNeighbours = 0;

                for (int d = 0; d < 8; d++)
                {
                    var ni = i + di[d];
                    var nj = j + dj[d];

                    if (ni >= 0 && ni < n && nj >= 0 && nj < m && (board[ni][nj] & live) == live)
                    {
                        liveNeighbours++;
                    }
                }

                if (board[i][j] == live && liveNeighbours is < 4 and > 1 || board[i][j] == dead && liveNeighbours is 3)
                {
                    board[i][j] |= live << 1;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (((board[i][j] >> 1) & live) == live)
                    board[i][j] = live;
                else
                    board[i][j] = dead;
            }
        }
    }

    private void GameOfLife_Matrix(int[][] board)
    {
        int n = board.Length;
        int m = board[0].Length;

        var ns = new int[n][];

        for (int i = 0; i < n; i++)
        {
            ns[i] = new int[m];
        }

        int[] di = { 0, 0, 1, -1, 1, 1, -1, -1 };
        int[] dj = { 1, -1, 0, 0, 1, -1, 1, -1 };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int live = 0;

                for (int d = 0; d < 8; d++)
                {
                    var ni = i + di[d];
                    var nj = j + dj[d];

                    if (ni >= 0 && ni < n && nj >= 0 && nj < m)
                    {
                        live += board[ni][nj];
                    }
                }

                if (board[i][j] == 1 && live is < 4 and > 1 || board[i][j] == 0 && live == 3)
                {
                    ns[i][j] = 1;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                board[i][j] = ns[i][j];
            }
        }
    }
}