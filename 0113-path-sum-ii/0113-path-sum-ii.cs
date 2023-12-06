public class Solution {
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum)
    {
        var res = new List<IList<int>>();

        dfs(root, 0, new List<int>());

        return res;

        void dfs(TreeNode? node, int sum, List<int> path)
        {
            if (node == null) return;

            path.Add(node.val);

            sum += node.val;

            if (node.left == null && node.right == null && sum == targetSum)
            {
                res.Add(path.ToArray());
            }
            else
            {
                dfs(node.left, sum, path);
                dfs(node.right, sum, path);
            }

            path.RemoveAt(path.Count - 1);
        }
    }
}