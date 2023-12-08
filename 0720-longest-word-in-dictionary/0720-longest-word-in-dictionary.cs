public class Solution
{
    public string LongestWord(string[] words)
    {
        var trie = new Trie();

        foreach (var word in words)
        {
            trie.Add(word);
        }

        string res = "";

        foreach (var word in words)
        {
            if ((word.Length > res.Length || word.Length == res.Length && string.CompareOrdinal(word, res) < 0) && trie.Check(word))
            {
                res = word;
            }
        }

        return res;
    }
}

public class Trie
{
    private readonly Node _root;

    public Trie()
    {
        _root = new Node();
    }

    public void Add(string word)
    {
        var root = _root;

        foreach (var c in word)
        {
            if (!root.Next.TryGetValue(c, out var next))
            {
                next = new Node();

                root.Next[c] = next;
            }

            root = next;
        }

        root.End = true;
    }

    public bool Check(string word)
    {
        var root = _root;

        foreach (var c in word)
        {
            if (!root.Next.TryGetValue(c, out var next) || !next.End)
            {
                return false;
            }

            root = next;
        }

        return true;
    }

    private class Node
    {
        public bool End { get; set; }
        public Dictionary<char, Node> Next { get; } = new();
    }
}