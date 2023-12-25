public class Solution {
    public int MissingNumber(int[] nums) 
    {
        return MissingNumber_ArithmeticProgression(nums);
    }

    private int MissingNumber_ArithmeticProgression(int[] nums) 
    {
        int n = nums.Length;
        int asum = (1 + n) * n / 2;
        int sum = 0;

        foreach(var num in nums)
        {
            sum += num;
        }

        return asum - sum;
    }

    private int MissingNumber_Xor(int[] nums) 
    {
        int xor = 0;

        for(int i = 1; i <= nums.Length; i++)
        {
            xor ^= i;
        }

        foreach(var num in nums)
        {
            xor ^= num;
        }

        return xor;
    }

    private int MissingNumber_HashSet(int[] nums)
    {
        var hs = new HashSet<int>();

        for(int i = 0; i <= nums.Length; i++)
        {
            hs.Add(i);
        }

        foreach(var num in nums)
        {
            hs.Remove(num);
        }

        return hs.First();
    }

    private int MissingNumber_Arr(int[] nums) 
    {
        var arr = new bool[nums.Length + 1];

        foreach(var num in nums)
        {
            arr[num] = true;
        }

        for(int i = 0; i < arr.Length; i++)
        {
            if (!arr[i])
            {
                return i;
            }
        }

        return -1;
    }
}