public class Solution {
    public string ReorganizeString(string s)
    {
        var freq = new int[26];

        foreach (var ch in s)
        {
            freq[ch - 'a']++;
        }

        var pq = new PriorityQueue<char, int>(Comparer<int>.Create((x, y) => y - x));

        for (int i = 0; i < 26; i++)
        {
            if (freq[i] > 0)
            {
                pq.Enqueue((char)(i + 'a'), freq[i]);
            }
        }

        var sb = new StringBuilder();

        var prev_ch = default(char);
        var prev_count = 0;

        while (pq.TryDequeue(out var ch, out var count))
        {
            sb.Append(ch);

            if (prev_ch != default)
            {
                pq.Enqueue(prev_ch, prev_count);

                prev_ch = default;
            }

            if (--count > 0)
            {
                prev_ch = ch;
                prev_count = count;
            }
        }

        if (prev_ch != default)
        {
            return "";
        }

        return sb.ToString();
    }
}