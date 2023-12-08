public class Solution
{
    public int WidthOfBinaryTree(TreeNode root)
    {
        var que = new Queue<(TreeNode, int)>();

        que.Enqueue((root, 0));

        int maxWidth = 0;

        while (que.Count > 0)
        {
            int firstind = -1;
            int lastind = -1;

            int n = que.Count;

            while (n-- > 0)
            {
                var (cur, ind) = que.Dequeue();

                if (cur.left != null)
                    que.Enqueue((cur.left, 2 * ind + 1));

                if (cur.right != null)
                    que.Enqueue((cur.right, 2 * ind + 2));

                if (firstind == -1)
                {
                    firstind = ind;
                }

                lastind = ind;
            }

            maxWidth = Math.Max(maxWidth, lastind - firstind + 1);
        }

        return maxWidth;
    }
}