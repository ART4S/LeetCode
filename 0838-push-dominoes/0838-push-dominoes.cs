public class Solution {
    // n
    public string PushDominoes(string dominoes)
    {
        dominoes = "L" + dominoes + "R";

        var res = dominoes.ToCharArray();

        for (int i = 1, j = 1; i < dominoes.Length - 1; i++)
        {
            if (dominoes[i] != '.') continue;

            if (dominoes[i - 1] != '.')
            {
                j = i;
            }

            if (dominoes[i + 1] != '.')
            {
                int l = j;
                int r = i;

                if (res[l - 1] == 'R' && res[r + 1] == 'L')
                {
                    while (l < r)
                    {
                        res[l] = res[l - 1];
                        res[r] = res[r + 1];

                        l++;
                        r--;
                    }
                }
                else if (res[l - 1] == 'R')
                {
                    while (l <= r)
                    {
                        res[l] = res[l - 1];
                        l++;
                    }
                }
                else if (res[r + 1] == 'L')
                {
                    while (l <= r)
                    {
                        res[r] = res[r + 1];
                        r--;
                    }
                }
            }
        }

        return new string(res, 1, res.Length - 2);
    }
}