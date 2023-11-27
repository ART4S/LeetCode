public class Solution {
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        for (int i = 0; i < n / 2; i++)
        {
            int m = n - i - 1;

            for (int j = i; j < m; j++)
            {
                var u = matrix[i][j];
                var r = matrix[j][m];
                var d = matrix[m][n - j - 1];
                var l = matrix[n-j-1][i];

                matrix[i][j] = l;
                matrix[j][m] = u;
                matrix[m][n - j - 1] = r;
                matrix[n-j-1][i] = d;
            }
        }
    }
}
