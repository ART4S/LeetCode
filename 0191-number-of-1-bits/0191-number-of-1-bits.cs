public class Solution {
    public int HammingWeight(uint n)
    {
        int res = 0;

        for (int i = 0, m = (int)n; i < 32; i++, m >>= 1)
        {
            res += m & 1;
        }

        return res;
    }
}