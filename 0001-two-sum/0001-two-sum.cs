public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        var arr = nums.Select((x, i) => (Index: i, Value: x)).OrderBy(x => x.Value).ToArray();

        int i = 0;
        int j = arr.Length - 1;

        while (i < j)
        {
            var sum = arr[i].Value + arr[j].Value;

            if (sum > target)
            {
                j--;
            }
            else if (sum < target)
            {
                i++;
            }
            else
            {
                return new[] { arr[i].Index, arr[j].Index };
            }
        }

        return Array.Empty<int>();
    }
}