public class Solution {
    public bool IsPalindrome(int x)
    {
        string s = x.ToString();

        int i = 0;
        int j = s.Length - 1;

        while (i < j)
        {
            if (s[i] != s[j]) return false;

            i++;
            j--;
        }

        return true;
    }
}