public class Solution {
    public int LongestConsecutive(int[] nums)
    {
        var set = new HashSet<int>();

        foreach (var num in nums)
        {
            set.Add(num);
        }

        var visited = new HashSet<int>();

        var maxLen = 0;

        foreach (var num in nums)
        {
            if (visited.Contains(num)) continue;

            var (len, n) = (1, num);

            while (set.Contains(--n))
            {
                len++;
                visited.Add(n);
            }

            n = num;

            while (set.Contains(++n))
            {
                len++;
                visited.Add(n);
            }

            maxLen = Math.Max(maxLen, len);
        }

        return maxLen;
    }
}