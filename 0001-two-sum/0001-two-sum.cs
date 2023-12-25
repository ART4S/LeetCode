public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var res = new int[2];
        var map = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            if (map.TryGetValue(target - nums[i], out var j))
            {
                res[0] = i;
                res[1] = j;
                
                break;
            }

            map[nums[i]] = i;
        }

        return res;
    }
}