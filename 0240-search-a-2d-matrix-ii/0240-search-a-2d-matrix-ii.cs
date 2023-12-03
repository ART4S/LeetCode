public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
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
}