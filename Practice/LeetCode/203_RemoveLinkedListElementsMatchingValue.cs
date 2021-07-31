namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class RemoveLinkedListElementsMatchingValue
    {
        //https://leetcode.com/problems/remove-linked-list-elements/
        public ListNode RemoveElements(ListNode head, int val) {
        
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        
        
        ListNode prev = dummy;
        ListNode curr = head;
        
        while(curr != null)
        {
            if(curr.val == val)
            {
                prev.next = curr.next;
            }
            else
            {           
                 prev = curr;
            }
            curr = curr.next;
        }
        
        return dummy.next;
     
    }
        
    }
}