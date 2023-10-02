public class Solution {
    public ListNode? ReverseList(ListNode? head)
    {
        ListNode? newHead = null;

        while (head != null)
        {
            var temp = head.next;
            head.next = newHead;
            newHead = head;
            head = temp;
        }

        return newHead;
    }
}