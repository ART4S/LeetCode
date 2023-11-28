public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        if (n > 45) return Array.Empty<IList<int>>();

        var res = new List<IList<int>>();

        var backtrack = new List<int>();

        var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        dfs(0, 0);

        return res;

        void dfs(int i, int sum)
        {
            if (backtrack.Count >= k || sum >= n || i == nums.Length)
            {
                if (backtrack.Count == k && sum == n)
                {
                    res.Add(backtrack.ToArray());
                }
                
                return;
            }

            dfs(i + 1, sum);

            backtrack.Add(nums[i]);
            dfs(i + 1, sum + nums[i]);
            backtrack.RemoveAt(backtrack.Count - 1);
        }
    }
}