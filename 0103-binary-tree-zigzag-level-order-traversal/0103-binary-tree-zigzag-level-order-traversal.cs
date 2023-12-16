public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
    {
        if (root == null) return Array.Empty<IList<int>>();

        var res = new List<IList<int>>();

        var que = new Queue<TreeNode>();

        que.Enqueue(root);

        while (que.Count > 0)
        {
            var level = new int[que.Count];

            int i = 0;
            int inc = 1;

            if (res.Count % 2 != 0)
            {
                (i, inc) = (level.Length - 1, -1);
            }

            while (i >= 0 && i < level.Length)
            {
                var cur = que.Dequeue();

                level[i] = cur.val;

                if (cur.left != null)
                    que.Enqueue(cur.left);

                if (cur.right != null)
                    que.Enqueue(cur.right);

                i += inc;
            }

            res.Add(level);
        }

        return res;
    }
}