public class Solution {
    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        return (root, subRoot) switch
        {
            (null, null) => true,
            (null, { }) => false,
            ({ }, null) => false,
            _ => CompareTrees(root, subRoot) || IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot)
        };
    }

    private static bool CompareTrees(TreeNode? a, TreeNode? b)
    {
        return (a, b) switch
        {
            (null, null) => true,
            (null, {}) => false,
            ({}, null) => false,
            _ => a.val == b.val && CompareTrees(a.left, b.left) && CompareTrees(a.right, b.right)
        };
    }
}