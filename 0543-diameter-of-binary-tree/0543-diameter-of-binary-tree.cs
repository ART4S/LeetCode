public class Solution
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int diameter = 0;

        _ = GetDepth(root, ref diameter);

        return diameter;
    }

    private static int GetDepth(TreeNode? root, ref int diameter)
    {
        if (root is null) return 0;

        int leftDepth = GetDepth(root.left, ref diameter);
        int rightDepth = GetDepth(root.right, ref diameter);

        diameter = Math.Max(diameter, leftDepth + rightDepth);

        return 1 + Math.Max(leftDepth, rightDepth);
    }
}