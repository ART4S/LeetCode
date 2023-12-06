public class Solution {
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum)
    {
        if (root == null) return Array.Empty<IList<int>>();

        var res = new List<IList<int>>();

        dfs(root, root.val, new List<int>(){ root.val });

        return res;

        void dfs(TreeNode node, int sum, List<int> path)
        {
            if (node.left == null && node.right == null && sum == targetSum)
            {
                res.Add(path.ToArray());
                return;
            }

            if (node.left != null)
            {
                path.Add(node.left.val);

                dfs(node.left, sum + node.left.val, path);

                path.RemoveAt(path.Count - 1);
            }

            if (node.right != null)
            {
                path.Add(node.right.val);

                dfs(node.right, sum + node.right.val, path);

                path.RemoveAt(path.Count - 1);
            }
        }
    }
}