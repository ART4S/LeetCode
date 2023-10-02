public class Solution {
    public bool IsBalanced(TreeNode? root)
    {
        var depth = new Dictionary<TreeNode, int>();

        _ = FindDepth(root, depth);

        return IsBalanced(root, depth);
    }

    private bool IsBalanced(TreeNode? root, Dictionary<TreeNode, int> depth)
    {
        if (root is null) return true;

        var ld = FindDepth(root.left, depth);
        var rd = FindDepth(root.right, depth);

        return Math.Abs(ld - rd) < 2 && IsBalanced(root.left, depth) && IsBalanced(root.right, depth);
    }

    private static int FindDepth(TreeNode? root, Dictionary<TreeNode, int> depth)
    {
        if (root is null) return 0;

        if (depth.TryGetValue(root, out var d))
        {
            return d;
        }

        return depth[root] = 1 + Math.Max(FindDepth(root.left, depth), FindDepth(root.right, depth));
    }
}