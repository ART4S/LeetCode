public class Solution {
    public string FrequencySort(string s)
    {
        var freq = new Dictionary<char, int>();

        foreach (var ch in s)
        {
            freq.TryAdd(ch, 0);
            freq[ch]++;
        }

        var sb = new StringBuilder();

        foreach (var (symbol, count) in freq.OrderByDescending(x => x.Value))
        {
            var c = count;

            while (c-- > 0)
            {
                sb.Append(symbol);   
            }
        }

        return sb.ToString();
    }
}