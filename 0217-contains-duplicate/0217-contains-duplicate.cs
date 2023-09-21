public class Solution {
    public bool ContainsDuplicate(int[] nums)
    {
        var occurrence = new HashSet<int>();

        foreach (var num in nums)
        {
            if (!occurrence.Add(num))
            {
                return true;
            }
        }

        return false;
    }
}
