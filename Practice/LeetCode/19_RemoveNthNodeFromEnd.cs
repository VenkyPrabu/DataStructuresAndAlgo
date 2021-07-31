namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class RemoveNthNodeFromEnd
    {
        //https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        public ListNode RemoveNthNode(ListNode head, int n)
        {

            if (head == null)
            {
                return null;
            }

            if (head.next == null && n == 1)
            {
                return null;
            }

            int length = 0;
            ListNode curr = head;
            while (curr != null)
            {
                length++;
                curr = curr.next;
            }

            ListNode prev = null;
            curr = head;

            for (int i = 0; i < length - n; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            if (prev == null)
            {
                head = head.next;
                return head;
            }

            prev.next = curr.next;

            return head;

        }
    }
}