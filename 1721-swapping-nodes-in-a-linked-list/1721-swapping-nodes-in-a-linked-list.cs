public class Solution {
    public ListNode SwapNodes(ListNode head, int k)
    {
        ListNode? l = null;
        ListNode? r = null;

        for (ListNode? cur = head; cur != null; cur = cur.next)
        {
            r = r?.next;

            if (--k == 0)
            {
                l = cur;
                r = head;
            }
        }

        (l.val, r.val) = (r.val, l.val);

        return head;
    }
}