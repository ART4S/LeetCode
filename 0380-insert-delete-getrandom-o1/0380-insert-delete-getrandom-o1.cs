public class RandomizedSet
{
    private readonly Dictionary<int, int> dict = new();
    private readonly List<int> list = new();

    public bool Insert(int val)
    {
        if (!dict.TryAdd(val, list.Count)) return false;

        list.Add(val);

        return true;
    }
    
    public bool Remove(int val)
    {
        if (!dict.TryGetValue(val, out var ind)) return false;

        dict[list[^1]] = ind;

        (list[^1], list[ind]) = (list[ind], list[^1]);

        list.RemoveAt(list.Count - 1);

        dict.Remove(val);

        return true;
    }
    
    public int GetRandom()
    {
        return list[Random.Shared.Next(list.Count)];
    }
}