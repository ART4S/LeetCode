public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        return DistanceK_FromRootToTargetPath(root, target, k);
    }

    private IList<int> DistanceK_FromRootToTargetPath(TreeNode root, TreeNode target, int k)
    {
        List<TreeNode> tp = null!; // Target Path

        findPath(root, new List<TreeNode>() { root });

        var res = new List<int>();

        int n = tp.Count;
        int dist = 0;

        for (int i = n - 1; i >= 0; i--, dist++)
        {
            if (dist == k)
            {
                res.Add(tp[i].val);
                break;
            }

            if (i == n - 1)
            {
                findKDist(tp[i].left, dist + 1);
                findKDist(tp[i].right, dist + 1);
            }
            else
            {
                if (tp[i].left != tp[i + 1])
                    findKDist(tp[i].left, dist + 1);
                else
                    findKDist(tp[i].right, dist + 1);
            }
        }

        return res;

        bool findPath(TreeNode node, List<TreeNode> path)
        {
            if (node == target)
            {
                tp = path;
                return true;
            }

            if (node.left != null)
            {
                path.Add(node.left);

                if (findPath(node.left, path)) return true;

                path.RemoveAt(path.Count - 1);
            }

            if (node.right != null)
            {
                path.Add(node.right);

                if (findPath(node.right, path)) return true;

                path.RemoveAt(path.Count - 1);
            }

            return false;
        }

        void findKDist(TreeNode? node, int dist)
        {
            if (node == null) return;

            if (dist == k)
            {
                res.Add(node.val);
                return;
            }

            findKDist(node.left, dist + 1);
            findKDist(node.right, dist + 1);
        }
    }

    private IList<int> DistanceK_AdjList(TreeNode root, TreeNode target, int k)
    {
        var adjList = buildAdjList(root);

        var que = new Queue<int>();

        que.Enqueue(target.val);

        var vis = new HashSet<int>() { target.val };

        while (que.Count > 0 && k-- > 0)
        {
            int n = que.Count;

            while (n-- > 0)
            {
                foreach (var next in adjList[que.Dequeue()])
                {
                    if (vis.Add(next))
                    {
                        que.Enqueue(next);
                    }
                }
            }
        }

        return que.ToArray();

        static Dictionary<int, List<int>> buildAdjList(TreeNode root)
        {
            var adjList = new Dictionary<int, List<int>>();

            var que = new Queue<TreeNode>();

            que.Enqueue(root);

            while (que.TryDequeue(out var cur))
            {
                if (!adjList.TryGetValue(cur.val, out var curAdj))
                {
                    curAdj = new List<int>();

                    adjList.Add(cur.val, curAdj);
                }

                if (cur.left != null)
                {
                    if (!adjList.TryGetValue(cur.left.val, out var leftAdj))
                    {
                        leftAdj = new List<int>();

                        adjList.Add(cur.left.val, leftAdj);
                    }

                    curAdj.Add(cur.left.val);
                    leftAdj.Add(cur.val);

                
                    que.Enqueue(cur.left);
                }

                if (cur.right != null)
                {
                    if (!adjList.TryGetValue(cur.right.val, out var rightAdj))
                    {
                        rightAdj = new List<int>();

                        adjList.Add(cur.right.val, rightAdj);
                    }

                    curAdj.Add(cur.right.val);
                    rightAdj.Add(cur.val);

                    que.Enqueue(cur.right);
                }
            }

            return adjList;
        }
    }
}