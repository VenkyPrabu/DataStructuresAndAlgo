namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class IntersectionofTwoLinkedLists
    {

        //https://leetcode.com/problems/intersection-of-two-linked-lists/submissions/
        public ListNode GetIntersectionNodeA(ListNode headA, ListNode headB)
        {
            ListNode ptrA = headA;
            ListNode ptrB = headB;
            ListNode intersectNode = null;

            while (ptrA != null)
            {
                ptrA.val = -ptrA.val;
                ptrA = ptrA.next;
            }

            while (ptrB != null)
            {
                if (ptrB.val < 0)
                {
                    intersectNode = ptrB;
                    break;
                }
                ptrB = ptrB.next;
            }

            ptrA = headA;
            while (ptrA != null)
            {
                ptrA.val = -ptrA.val;
                ptrA = ptrA.next;
            }

            return intersectNode;
        }
    

        public ListNode GetIntersectionNodeB(ListNode headA, ListNode headB) {
        
        //get the length of both lists
        int lenA = 0;
        int lenB = 0;
        ListNode ptrA = headA;
        ListNode ptrB = headB;
        
        while(ptrA != null)
        {
            lenA++;
            ptrA = ptrA.next;
        }
        
        while(ptrB != null)
        {
            lenB++;
            ptrB = ptrB.next;
        }
        
        
        if(lenA > lenB)
        {
            ptrA = headA;
            ptrB = headB;
            for(int i = 0; i < lenA - lenB; i++)
            {
                ptrA = ptrA.next;
            }
        }
        else 
        {
            ptrA = headA;
            ptrB = headB;
            for(int i = 0; i < lenB - lenA; i++)
            {
                ptrB = ptrB.next;
            }
        }
        
        while(ptrA != ptrB)
        {
            ptrA = ptrA.next;
            ptrB = ptrB.next;
        }
        
        return ptrA;
        
        
        
    }   
    
    }
}