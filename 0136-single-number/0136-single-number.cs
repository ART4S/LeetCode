public class Solution {
    public int SingleNumber(int[] nums)
    {
        var x = 0;

        foreach(var n in nums)
        {
            x ^= n;
        }

        return x;
    }
}