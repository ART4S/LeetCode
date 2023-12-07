public class Solution {
    public TreeNode? ConstructMaximumBinaryTree(int[] nums)
    {
        return ConstructMaximumBinaryTree_Stack(nums);
    }

    // n
    private TreeNode? ConstructMaximumBinaryTree_Stack(int[] nums)
    {
        var stack = new Stack<TreeNode>();

        var fake = new TreeNode(int.MaxValue);

        stack.Push(fake);

        foreach (var num in nums)
        {
            var node = new TreeNode(num);

            while (stack.Count > 0 && stack.Peek().val < node.val)
            {
                node.left = stack.Pop();
            }

            stack.Peek().right = node;

            stack.Push(node);
        }

        return fake.right;
    }

    // n^2
    private TreeNode? ConstructMaximumBinaryTree_DFS(int[] nums)
    {
        return dfs(0, nums.Length - 1);

        TreeNode? dfs(int l, int r)
        {
            if (l > r) return null;

            int m = l;

            for (int i = l; i <= r; i++)
            {
                if (nums[m] < nums[i])
                {
                    m = i;
                }
            }

            return new TreeNode(nums[m])
            {
                left = dfs(l, m - 1),
                right = dfs(m + 1, r)
            };
        }
    }
}