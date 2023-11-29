public class Solution {
    public ListNode? OddEvenList(ListNode? head)
    {
        if (head == null) return null;

        ListNode headOdd = new(0);
        ListNode headEven = new(0);
        ListNode tailOdd = headOdd;
        ListNode tailEven = headEven;

        bool even = false;

        for (ListNode? cur = head; cur != null; cur = cur.next)
        {
            if (even)
            {
                tailEven.next = cur;
                tailEven = cur;
            }
            else
            {
                tailOdd.next = cur;
                tailOdd = cur;
            }

            even = !even;   
        }

        if (headEven != tailEven)
        {
            tailOdd.next = headEven.next;

            tailEven.next = null;
        }

        return headOdd.next;
    }
}