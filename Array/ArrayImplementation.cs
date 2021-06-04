using System;

namespace DataStructuresAndAlgo.Array
{
    public class ArrayImplementation
    {
        static int sizeOfArray= 0;
        static int[] myarray;
        static long currLength = 0;
        public void main()
        {
            //Array Operations
            //1. Create Array with user provided length - Done
            //2. Print Array - O(n) - Done
            //3. Add at End - O(1) - Done
            //4. Add at Start - O(n) -Done
            //5. Add at a given Index- O(n) - Done
            //6. Delete at End -O(1) - Done
            //7. Delete at Start -O(n) - Done
            //8. Delete at a given Index -O(n) - Done
            //9. Search - Doing only Linear search here
            //11. Find Min - O(n)
            //12. Reverse using auxillary array - O(n)
            //13. Reverse without auxillary array - O(n) but Space O(1)
            //14. Left Shift - O(n)
            //15. Left Rotate - O(n)
            //16. Right Shift - O(n)
            //17. Right Rotate - O(n) 
            //18. Sum and Average - O(n)
            //19. Insert in a sorted array 1 - FInd IDX where need to be inserted then use Insert at IDX method to insert - O(n)
            //20. Insert in a sorted array 2 - Insert Directly by start shifting (better perf than #19) - O(n)
            //21. Check if array is sorted -O(n)
            //22. Merge two Sorted Arrays -O(n)
            //23. Union - Simillar to Merge with little variation 
            //24. Intersection - Simillar to Merge with little variation 
            //25. Difference - Simillar to Merge with little variation 

            //To DO
            //1. Sort - TO DO ---in Algorithm
            //2. Search - Binary search
            //3. Negative numbers on left and Positive numbers on Right - (Two pointer approach)
            //4. LeetCode - Array 101
            //5. Abdul Badri - Student Challenges       

            populateInitialArray();

            insertAtIndex(10,2);

            insertAtStart(99);

            printArray();

            deleteAtIndex(2);

            printArray();

            deleteAtStart();

            deleteAtEnd();

            printArray();

        }

        public void printArray()
        {
            for(int i = 0; i < currLength; i++)
            {
                Console.WriteLine("Array value at index {0} is {1}",i, myarray[i]);
            }

            Console.WriteLine("The length of the array : {0}", currLength);
            Console.WriteLine("------------------------------------");
        }
        public void populateInitialArray()
        {
            Console.WriteLine("Enter the total number of Elements : ");
            sizeOfArray = Convert.ToInt32(Console.ReadLine());
            myarray = new int[sizeOfArray];
            for(int i =0; i < sizeOfArray; i++)
            {
                Console.WriteLine("Enter the array value at index {0} : ", i);
                var value = Console.ReadLine();
                if(value == "E")
                {
                    break;
                }
                insertAtEnd(Convert.ToInt32(value));
            }          
        }
        public void insertAtEnd(int value)
        {
            Console.WriteLine("------insertAtEnd---------");
            if(currLength == sizeOfArray)
            {
                Console.WriteLine("Array is full and cannot insert any more elements");
                return;
            }
            myarray[currLength] = value;
            currLength++;
        }
        public void insertAtIndex(int value, int index)
        {
            Console.WriteLine("------insertAtIndex---------");
            if(index < 0 || index > sizeOfArray)
            {
                Console.WriteLine("Given index is more than the size of the array Or Wrong index value");
                return;
            }

            if(currLength == sizeOfArray)
            {
                Console.WriteLine("Array is full and cannot insert any more elements");
                return;
            }

            for(long i = currLength; i > index; i--)
            {
                myarray[i] = myarray[i-1];
            }

            myarray[index] = value;

            currLength++;
        }
        public void insertAtStart(int value)
        {
            //insert at start is the same as insertAtIndex but with the index always as 0
            insertAtIndex(value,0);
        }
        public void deleteAtIndex(int index)
        {
            Console.WriteLine("------deleteAtIndex---------");
            if(index >= 0 && index <= sizeOfArray)
            {
                int x = myarray[index];

                for(int i = index; i < currLength-1; i++)
                {
                    myarray[i] = myarray[i+1];
                }

                myarray[currLength-1] = -100;
                currLength--;
            }
            else
            {
                if(currLength == 0)
                {
                    Console.WriteLine("No element to delete");
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong index value");
                    return;
                }
            }
        }
        public void deleteAtStart()
        {
            deleteAtIndex(0);
        }

        public void deleteAtEnd()
        {
            if(currLength == 0)
            {
                Console.WriteLine("No element to delete");
                return;
            }
            myarray[currLength-1] = -100;
            currLength--;
        }
    }
}