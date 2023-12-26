public class Solution {
    public int[] CountBits(int n)
    {
        int[] res = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            int m = i;
            
            while (m != 0)
            {
                res[i] += m & 1;
                m >>= 1;
            }
        }

        return res;
    }
}