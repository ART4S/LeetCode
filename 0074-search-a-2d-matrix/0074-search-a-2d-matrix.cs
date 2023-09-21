public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int i = 0;
        int j = 0;

        while (true)
        {
            if (matrix[i][j] == target)
            {
                return true;
            }

            if (i + 1 < n && matrix[i + 1][j] <= target)
            {
                i++;
            }
            else if (j + 1 < m && matrix[i][j + 1] <= target)
            {
                j++;
            }
            else
            {
                return false;
            }
        }
    }
}