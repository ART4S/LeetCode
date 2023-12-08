public class Solution {
    public int FindMaximumXOR(int[] nums)
    {
        var trie = new Trie();

        foreach (var num in nums)
        {
            var root = trie;

            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;

                var next = root.Next[bit];

                if (next == null)
                {
                    next = new Trie();

                    root.Next[bit] = next;
                }

                root = next;
            }
        }

        int maxXor = 0;

        foreach (var num in nums)
        {
            int xor = 0;

            var root = trie;

            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;

                if (root.Next[1 - bit] != null)
                {
                    root = root.Next[1 - bit];

                    xor += 1 << i;
                }
                else
                {
                    root = root.Next[bit];
                }
            }

            maxXor = Math.Max(maxXor, xor);
        }

        return maxXor;
    }
}

public class Trie
{
    public Trie?[] Next { get; } = new Trie?[2];
}