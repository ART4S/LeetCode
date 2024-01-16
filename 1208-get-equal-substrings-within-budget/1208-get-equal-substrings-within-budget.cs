public class Solution {
    // n
    public int EqualSubstring(string s, string t, int maxCost)
    {
        int cost = 0;

        int i = 0;
        int j = 0;

        while (i < s.Length)
        {
            cost += Math.Abs(s[i] - t[i]);

            if (cost > maxCost)
            {
                cost -= Math.Abs(s[j] - t[j]);

                j++;
            }

            i++;
        }

        return i - j;
    }
}