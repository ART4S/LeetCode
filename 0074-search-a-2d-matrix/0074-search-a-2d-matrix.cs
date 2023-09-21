public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int l = 0;
        int r = matrix.Length - 1;

        while (l <= r)
        {
            var m = l + (r - l) / 2;

            var row = matrix[m];

            switch (row[0] - target)
            {
                case > 0:
                    r = m - 1;
                    break;
                case < 0:
                    switch (row[^1] - target)
                    {
                        case > 0:
                            l = 0;
                            r = row.Length - 1;

                            while (l <= r)
                            {
                                int mm = l + (r - l) / 2;

                                if (row[mm] == target) return true;
                                if (row[mm] < target)
                                    l = mm + 1;
                                else
                                    r = mm - 1;
                            }
                            return false;
                        case < 0:
                            l = m + 1;
                            break;
                        default:
                            return true;
                    }
                    break;

                default: return true;
            }
        }

        return false;
    }
}