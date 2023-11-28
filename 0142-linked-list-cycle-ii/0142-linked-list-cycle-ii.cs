public class Solution {
    // O(1) space, O(n^2) time 
    public ListNode? DetectCycle(ListNode? head)
    {
        if (head == null) return null;

        ListNode slow = head;
        ListNode? fast = head.next?.next;

        while (fast != null && slow != fast)
        {
            slow = slow.next;
            fast = fast.next?.next;
        }

        if (fast == null) return null;

        while(true)
        {
            ListNode? cur = fast?.next;

            while (cur != fast && cur != head)
            {
                cur = cur?.next;
            }

            if (cur == head) break;

            head = head?.next;
        }

        return head;
    }
}