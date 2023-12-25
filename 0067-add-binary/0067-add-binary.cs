public class Solution {
    public string AddBinary(string a, string b)
    {
        int n = Math.Max(a.Length, b.Length) + 1;
        int i = a.Length - 1;
        int j = b.Length - 1;
        int k = n - 1;

        var res = new char[n];

        int carry = 0;

        while (i >= 0 || j >= 0)
        {
            int x = 0;
            int y = 0;

            if (i >= 0) x = a[i--] - '0';

            if (j >= 0) y = b[j--] - '0';

            res[k--] = (char)((carry ^ x ^ y) + '0');

            carry = carry + x + y > 1 ? 1 : 0;
        }

        if (carry == 0)
        {
            return new string(res, 1, n - 1);
        }

        res[0] = '1';

        return new string(res);
    }
}