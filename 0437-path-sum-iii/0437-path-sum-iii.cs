public class Solution {
    public int PathSum(TreeNode root, int targetSum)
    {
        return PathSum_PrefixSumDict(root, targetSum);
    }

    private int PathSum_PrefixSumDict(TreeNode root, int targetSum)
    {
        int res = 0;

        dfs(root, 0, new Dictionary<long, int>() { [0] = 1 });

        return res;

        void dfs(TreeNode? root, long sum, Dictionary<long, int> prefixSum)
        {
            if (root == null) return;

            sum += root.val;

            if (prefixSum.TryGetValue(sum - targetSum, out var freq))
            {
                res += freq;
            }

            prefixSum.TryAdd(sum, 0);
            
            prefixSum[sum]++;

            dfs(root.left, sum, prefixSum);
            dfs(root.right, sum, prefixSum);

            prefixSum[sum]--;
        }
    }

    private int PathSum_PrefixSumList(TreeNode root, int targetSum)
    {
        int res = 0;

        dfs(root, new List<long>());

        return res;

        void dfs(TreeNode? root, List<long> prefixSum)
        {
            if (root == null) return;

            if (prefixSum.Count > 0)
                prefixSum.Add(prefixSum[^1] + root.val);
            else
                prefixSum.Add(root.val);

            for (int i = 0; i < prefixSum.Count; i++)
            {
                long prevSum = i == 0 ? 0 : prefixSum[i - 1];

                if (prefixSum[^1] - prevSum == targetSum)
                {
                    res++;
                }
            }

            dfs(root.left, prefixSum);
            dfs(root.right, prefixSum);

            prefixSum.RemoveAt(prefixSum.Count - 1);
        }
    }
}