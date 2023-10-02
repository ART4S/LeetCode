public class Solution {
    public bool IsValidSudoku(char[][] board)
    {
        var rows = new bool[90];
        var cols = new bool[90];
        var squares = new bool[90];

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] == '.') continue;

                int num = board[i][j] - '0';

                int r = i * 10 + num;
                int c = j * 10 + num;
                int s = (3 * (i / 3) + j / 3) * 10 + num;

                if (!rows[r] && !cols[c] && !squares[s])
                    rows[r] = cols[c] = squares[s] = true;
                else
                    return false;
            }
        }

        return true;
    }
}