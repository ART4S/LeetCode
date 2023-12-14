public class Solution {
    public int SumNumbers(TreeNode root)
    {
        return dfs(root, 0);

        int dfs(TreeNode node, int prevnum)
        {
            int num = prevnum * 10 + node.val;
            int sum = 0;

            if (node.left != null)
                sum += dfs(node.left, num);

            if (node.right != null)
                sum += dfs(node.right, num);

            return sum > 0 ? sum : num;
        }
    }
}