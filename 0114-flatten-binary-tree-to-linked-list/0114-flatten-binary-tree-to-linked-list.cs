public class Solution {
    public void Flatten(TreeNode? root)
    {
        TreeNode? tail = null;

        dfs_post(root);

        void dfs_post(TreeNode? node)
        {
            if (node == null) return;

            dfs_post(node.right);
            dfs_post(node.left);

            node.right = tail;
            node.left = null;
            tail = node;
        }

        void dfs_pre(TreeNode? node)
        {
            if (node == null) return;

            if (tail == null)
            {
                tail = node;
            }
            else
            {
                tail.right = node;
                tail = tail.right;
            }

            var r = node.right;

            dfs_pre(node.left);
            dfs_pre(r);

            node.left = null;
        }
    }
}