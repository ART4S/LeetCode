public class Solution {
    public int StrStr(string haystack, string needle)
    {
        if (haystack.Length < needle.Length) return -1;

        for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            if (CheckOccurrence(i, haystack, needle))
            {
                return i;
            }
        }

        return -1;
    }

    private bool CheckOccurrence(int index, string haystack, string needle)
    {
        for (int i = index, j = 0; i < haystack.Length && j < needle.Length; i++, j++)
        {
            if (haystack[i] != needle[j])
            {
                return false;
            }
        }

        return true;
    }
}