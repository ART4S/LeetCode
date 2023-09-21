public class Solution {
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        return (p, q) switch
        {
            (null, null) => true,
            ({ }, null) => false,
            (null, { }) => false,
            _ => p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right)
        };
    }
}