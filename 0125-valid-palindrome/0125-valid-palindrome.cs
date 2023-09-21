public class Solution {
    public bool IsPalindrome(string s) {

        int l = 0;
        int r = s.Length - 1;

        while (true)
        {
            while (l <= r && !char.IsLetterOrDigit(s[l]))
            {
                l++;
            }

            while (r >= l && !char.IsLetterOrDigit(s[r]))
            {
                r--;
            }

            if (r < l)
            {
                return true;
            }

            if (char.ToLower(s[l]) != char.ToLower(s[r]))
            {
                return false;
            }

            r--;
            l++;
        }
    }
}