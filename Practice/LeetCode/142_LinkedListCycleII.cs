namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class LinkedListCycleII
    {
        //https://leetcode.com/problems/linked-list-cycle-ii/

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }
            var intersectNode = IntersectionNode(head);
            if (intersectNode == null)
            {
                return null;
            }
            ListNode ptr1 = head;
            ListNode ptr2 = intersectNode;
            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }
            return ptr1;

        }

        public ListNode IntersectionNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return slow;
                }
            }
            return null;
        }
    }
}