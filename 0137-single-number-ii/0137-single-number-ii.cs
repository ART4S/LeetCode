public class Solution {
    public int SingleNumber(int[] nums)
    {
        var map = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            map.TryAdd(num, 0);

            if (++map[num] == 3)
            {
                map.Remove(num);
            }
        }

        return map.Keys.First();
    }
}