public class Solution {
    public ListNode? SortList(ListNode? head)
    {
        var nodes = new List<int>();

        for (ListNode? cur = head; cur != null; cur = cur.next)
        {
            nodes.Add(cur.val);
        }

        nodes.Sort();

        int i = 0;

        for (ListNode? cur = head; cur != null; cur = cur.next)
        {
            cur.val = nodes[i++];
        }

        return head;
    }
}