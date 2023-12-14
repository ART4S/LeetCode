public class BSTIterator
{
    private readonly Stack<TreeNode> stack = new();
    private TreeNode? root;

    public BSTIterator(TreeNode root)
    {
        this.root = root;
    }

    public int Next()
    {
        while (root != null)
        {
            stack.Push(root);
            root = root.left;
        }

        root = stack.Pop();

        int res = root.val;

        root = root.right;

        return res;
    }

    public bool HasNext()
    {
        return root != null || stack.Count > 0;
    }
}

public class BSTIterator_List
{
    private readonly List<int> elems = new();
    private int pos = 0;

    public BSTIterator_List(TreeNode root)
    {
        traverse(root);

        void traverse(TreeNode? root)
        {
            if (root == null) return;

            traverse(root.left);
            elems.Add(root.val);
            traverse(root.right);
        }
    }

    public int Next()
    {
        if (pos < elems.Count) return elems[pos++];

        return -1;
    }
    
    public bool HasNext()
    {
        return pos < elems.Count;
    }
}