public class Solution {
    public int MaxVowels(string s, int k)
    {
        int v = 0;
        int maxv = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (IsVovel(s[i])) v++;
            
            if (i >= k && IsVovel(s[i - k])) v--;
            
            maxv = Math.Max(maxv, v);
        }

        return maxv;
    }

    private bool IsVovel(char c)
    {
        switch (c)
        {
            case 'a':
            case 'e' :
            case 'i' :
            case 'o' :
            case 'u' :
                return true;

            default: return false;
        }
    }
}