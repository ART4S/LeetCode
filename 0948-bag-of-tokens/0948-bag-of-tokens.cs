public class Solution {
    // n log n
    public int BagOfTokensScore(int[] tokens, int power)
    {
        Array.Sort(tokens);

        int n = tokens.Length;

        int l = 0;
        int r = n - 1;

        int p = power;
        int s = 0;

        while (l <= r)
        {
            if (p >= tokens[l])
            {
                p -= tokens[l];
                s++;
            }
            else if (s > 0 && l != r && p + tokens[r] >= tokens[l])
            {
                p = p + tokens[r] - tokens[l];

                r--;
            }

            l++;
        }

        return s;
    }
}