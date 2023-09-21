public class Solution {
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length is 0) return string.Empty;

        var prefix = strs[0].AsSpan();

        for (int i = 1; i < strs.Length; i++)
        {
            int len = Math.Min(prefix.Length, strs[i].Length);

            int j = 0;

            while (j < len && strs[i][j] == prefix[j])
            {
                j++;
            }

            prefix = prefix[..j];

            if (prefix.Length is 0)
            {
                return string.Empty;
            }
        }

        return prefix.ToString();
    }
}