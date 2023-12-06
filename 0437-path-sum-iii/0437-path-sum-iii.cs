public class Solution {
    public int PathSum(TreeNode root, int targetSum)
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