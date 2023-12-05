public class Solution {
    public Node? Connect(Node? root)
    {
        return Connect_LinkedList(root);
    }

    private Node? Connect_LinkedList(Node? root)
    {
        var res = root;

        var fakenode = new Node();

        while (root?.left != null)
        {
            var prev = fakenode;

            for (var cur = root; cur != null; cur = cur.next)
            {
                prev.next = cur.left;
                cur.left.next = cur.right;
                prev = cur.right;
            }

            root = root.left;
        }

        return res;
    }

    private Node? Connect_BFS(Node? root)
    {
        if (root == null) return null;

        var que = new Queue<Node>();

        que.Enqueue(root);

        var fakeNode = new Node();

        while (que.Count > 0)
        {
            int n = que.Count;

            Node prev = fakeNode;

            while (n-- > 0)
            {
                var cur = que.Dequeue();

                prev.next = cur;

                prev = cur;

                if (cur.left != null)
                    que.Enqueue(cur.left);

                if (cur.right != null)
                    que.Enqueue(cur.right);
            }
        }

        return root;
    }
}