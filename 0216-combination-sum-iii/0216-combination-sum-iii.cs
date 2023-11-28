public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        if (n > 45) return Array.Empty<IList<int>>();

        var res = new List<IList<int>>();

        var bt = new List<int>();

        var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        dfs(0, 0);

        return res;

        void dfs(int i, int sum)
        {
            if (bt.Count >= k || sum >= n || i == nums.Length)
            {
                if (bt.Count == k && sum == n)
                {
                    res.Add(bt.ToArray());
                }
                
                return;
            }

            dfs(i + 1, sum);

            bt.Add(nums[i]);
            dfs(i + 1, sum + nums[i]);
            bt.RemoveAt(bt.Count - 1);
        }
    }
}