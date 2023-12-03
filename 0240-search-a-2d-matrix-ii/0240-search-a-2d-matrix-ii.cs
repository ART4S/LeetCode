public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        return SearchMatrix_Traverse(matrix, target);
    }

    // nlog(n)
    private bool SearchMatrix_BinSearch(int[][] matrix, int target)
    {
        foreach (var row in matrix)
        {
            int l = 0;
            int r = row.Length - 1;

            while (l < r)
            {
                int m = l + (r - l) / 2;

                if (row[m] < target)
                    l = m + 1;
                else
                    r = m;
            }

            if (row[l] == target)
            {
                return true;
            }
        }

        return false;
    }

    // n + m
    private bool SearchMatrix_Traverse(int[][] matrix, int target)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int i = 0;
        int j = m - 1;

        while (true)
        {
            if (matrix[i][j] == target) return true;

            if (matrix[i][j] > target && j > 0)
                j--;
            else if (matrix[i][j] < target && i < n - 1)
                i++;
            else
                return false;
        }
    }
}