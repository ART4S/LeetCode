public class Solution {
    public Node? Connect(Node? root)
    {
        return Connect_Iterative(root);
    }

    private Node? Connect_Iterative(Node? root)
    {
        var fake = new Node();

        var cur = root;

        while (cur != null)
        {
            Node? next = null;

            Node level = fake;

            for (var node = cur; node != null; node = node.next)
            {
                if (node.left != null)
                {
                    level.next = node.left;
                    level = level.next;
                    next ??= level;
                }

                if (node.right != null)
                {
                    level.next = node.right;
                    level = level.next;
                    next ??= level;
                }
            }

            cur = next;
        }

        return root;
    }

    private Node? Connect_BFS(Node? root)
    {
        if (root == null) return null;

        var que = new Queue<Node>();

        que.Enqueue(root);

        var fake = new Node();

        while (que.Count > 0)
        {
            int n = que.Count;

            var level = fake;

            while (n-- > 0)
            {
                var node = que.Dequeue();

                level.next = node;

                level = node;

                if (node.left != null)
                    que.Enqueue(node.left);

                if (node.right != null)
                    que.Enqueue(node.right);
            }
        }

        return root;
    }
}