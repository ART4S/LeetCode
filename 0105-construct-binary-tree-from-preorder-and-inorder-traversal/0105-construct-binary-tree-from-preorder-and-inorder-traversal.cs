public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }

    private TreeNode? BuildTree(int[] preorder, int pi, int pj, int[] inorder, int ii, int ij)
    {
        var node = new TreeNode(preorder[pi]);

        int i;

        for (i = ii; i <= ij; i++)
        {
            if (inorder[i] == node.val)
            {
                break;
            }
        }

        int leftNodesCount = i - ii;
        int rightNodesCount = ij - i;

        if (leftNodesCount > 0)
        {
            node.left = BuildTree(preorder, pi + 1, pi + leftNodesCount, inorder, ii, i - 1);
        }

        if (rightNodesCount > 0)
        {
            node.right = BuildTree(preorder, pi + 1 + leftNodesCount, pj, inorder, i + 1, ij);
        }

        return node;
    }
}