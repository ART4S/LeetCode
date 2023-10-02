public class Solution {
    public int RomanToInt(string s)
    {
        var numbers = new Dictionary<char, int>()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000,
        };

        var (prev, res) = (0, 0);

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int cur = numbers[s[i]];

            if (cur < prev)
                res -= cur;
            else
                res += cur;

            prev = cur;
        }

        return res;
    }
}