public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode res = null!;

        if (isDescendant(p, q))
            res = p;
        else if (isDescendant(q, p))
            res = q;
        else 
            findLCA(root);

        return res;

        bool findLCA(TreeNode? root)
        {
            if (root == null) return false;

            if (root == p || root == q) return true;

            bool foundl = findLCA(root.left);
            bool foundr = findLCA(root.right);

            if (foundl && foundr)
            {
                res = root;
            }

            return foundl || foundr;
        }

        bool isDescendant(TreeNode? node, TreeNode target)
        {
            if (node == null) return false;

            return node == target || isDescendant(node.left, target) || isDescendant(node.right, target);
        }
    }
}