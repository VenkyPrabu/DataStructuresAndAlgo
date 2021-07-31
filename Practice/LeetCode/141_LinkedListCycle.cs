namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class LinkedListCycle
    {


        public bool HasCycle(ListNode head)
        {
            if(head == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            while(slow!=null && fast!=null && fast.next !=null)
            {
                slow = slow.next;
                fast = fast.next;
                fast = fast.next;
                if(slow == fast)
                {
                    return true;
                }
            }

            return false;

        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}