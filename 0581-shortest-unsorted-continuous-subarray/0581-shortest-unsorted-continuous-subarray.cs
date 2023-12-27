public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        return FindUnsortedSubarray_Stack(nums);
    }

    // n
    private int FindUnsortedSubarray_Stack(int[] nums)
    {
        int n = nums.Length;

        int l = int.MaxValue;
        int r = int.MinValue;

        var stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            while (stack.TryPeek(out var j) && nums[j] > nums[i])
            {
                stack.Pop();
                l = Math.Min(l, j);
            }

            stack.Push(i);
        }

        stack.Clear();

        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.TryPeek(out var j) && nums[j] < nums[i])
            {
                stack.Pop();
                r = Math.Max(r, j);
            }

            stack.Push(i);
        }

        return l >= r ? 0 : r - l + 1;
    }

    // n
    private int FindUnsortedSubarray_CountingSort(int[] nums)
    {
        int n = nums.Length;

        int max = nums.Max(x => x);
        int min = nums.Min(x => x);

        int[] count = new int[max - min + 1];

        foreach (var num in nums)
        {
            count[num - min]++;
        }

        var sorted = new List<int>(n);

        for (int i = 0; i < count.Length; i++)
        {
            while (count[i]-- != 0)
            {
                sorted.Add(i + min);
            }
        }

        int l = 0;
        int r = n - 1;

        while (l < r && nums[l] == sorted[l]) l++;
        while (l < r && nums[r] == sorted[r]) r--;

        return l >= r ? 0 : r - l + 1;  
    }

    // n logn
    private int FindUnsortedSubarray_Sort(int[] nums)
    {
        int max = nums.Max(x => x);
        int min = nums.Min(x => x);

        int n = nums.Length;

        var sorted = nums.OrderBy(x => x).ToArray();

        int l = 0;
        int r = n - 1;

        while (l < r && nums[l] == sorted[l]) l++;
        while (l < r && nums[r] == sorted[r]) r--;

        return l >= r ? 0 : r - l + 1;   
    }
}