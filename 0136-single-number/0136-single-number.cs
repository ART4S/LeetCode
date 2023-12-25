public class Solution {
    public int SingleNumber(int[] nums) {
        return SingleNumber_Xor(nums);
    }

    private int SingleNumber_Xor(int[] nums) {
        var xor = 0;

        foreach (var num in nums)
        {
            xor ^= num;
        }

        return xor;
    }

    private int SingleNumber_HashSet(int[] nums)
    {
        var hs = new HashSet<int>();

        foreach (var num in nums)
        {
            if (!hs.Add(num))
            {
                hs.Remove(num);
            }
        }

        return hs.First();
    }
}