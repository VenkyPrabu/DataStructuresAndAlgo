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
            //9. Search - Doing only Linear search here - O(n)- Done
            //10. Search - Binary Search Iterative - O(log n) - Done
            //10-1. Search - Binary Search Recursive - O(log n) - Done
            //11. Find Min & Max - O(n) -Done
            //12. Reverse using auxillary array - O(n) - Done
            //13. Reverse without auxillary array - O(n) but Space O(1) - Done
            //14. Left Shift - O(n) - Done (same as Left rotate, but setting default the last elem = 0)
            //15. Left Rotate - O(n) - Done (With Iterative method to do n number of rotations)
            //16. Right Shift - O(n) - Done (same as Left rotate, but setting default the first elem = 0)
            //17. Right Rotate - O(n) - Done (With Iterative method to do n number of rotations)
            //18. Sum (Iterative and Recursive) and Average - O(n) - Done
            //19. Insert in a sorted array 1 - FInd IDX where need to be inserted then use Insert at IDX method to insert - O(n)
            //20. Insert in a sorted array 2 - Insert Directly by start shifting (better perf than #19) - O(n) - Done
            //21. Check if array is sorted -O(n) - Done
            //22. Merge two Sorted Arrays -O(n) - Done
            //23. Union (sorted arrays) - Simillar to Merge with little variation - O(n) - Done
            //24. Intersection - Simillar to Merge with little variation - Done
            //25. Difference - Simillar to Merge with little variation  - Done

            //To DO
            //1. Sort - TO DO ---in Algorithm
            //2. Search - Binary search - Done
            //3. Negative numbers on left and Positive numbers on Right - (Two pointer approach) - Done
            //4. LeetCode - Array 101
            //5. Abdul Badri - Student Challenges       

            
            #region calls
            // insertAtIndex(10,2);
            // insertAtStart(99);
            // printArray();
            // deleteAtIndex(2);
            // printArray();
            // deleteAtStart();
            // deleteAtEnd();
            // printArray();
            // search(99);
            // printArray();
            // Console.WriteLine("========Binary Iterative=========");
            // SearchBinary(99);  
            // Console.WriteLine("========Binary Recursive=========");
            // SearchBinaryRecursive(919,0,currLength-1);
            // Console.WriteLine("========Min=========");
            // Min();
            // Console.WriteLine("========Max=========");
            // Max();
            // Sum();
            // SumRecursive(0,0);
            // Avg();
            // Console.WriteLine("========ReverseWithAuxArray=========");
            // ReverseWithAuxArray();
            // Console.WriteLine("========ReverseWithoutAuxArray=========");
            // ReverseWithoutAuxArray();
            // Console.WriteLine("========LeftRotate=========");
            // LeftRotate(2);
            // printArray();
            // Console.WriteLine("========RightRotate=========");
            // RightRotate(2);
            // printArray();
            // Console.WriteLine("========RightRotate=========");
            // InsertInASortedArray(88);
            // IsSortedArray(new int[5]{1,9,3,4,5});
            // ArrangeNegativeOnLeftPositiveOnRight();
            // MergeSortedArray(new int[5]{4,7,9,11,22}, new int[6]{1,2,3,23,55,99});
            //UnionArray(new int[5]{3,4,5,6,10},new int[5]{2,4,5,7,12});
            //IntersectionArray(new int[5]{3,4,5,6,10}, new int[5]{2,4,5,7,12});
            //DifferenceArray(new int[6]{1,2,3,4,5,9},new int[5]{2,3,6,7,8});
            //populateInitialArray();
            #endregion

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
        public void printArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Array value at index {0} is {1}",i, array[i]);
            }

            Console.WriteLine("The length of the array : {0}", array.Length);
            Console.WriteLine("------------------------------------");
        }
        public void populateInitialArrayUserInput()
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
        public void populateInitialArray()
        {
            sizeOfArray = 15;
            currLength = 10;
            myarray = new int[15] {1,2,3,4,5,6,7,8,9,99,0,0,0,0,0};
            printArray();
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
        public void search(int value)
        {
            for(int i = 0; i < currLength -1; i++)
            {
                if(myarray[i] == value)
                {
                    Console.WriteLine("The value {0} is present at index {1}", value,i);
                    return;
                }
                    
            }

            Console.WriteLine("The value {0} is  not present in the array", value);
        }
        public void SearchBinary(int value)
        {
            double l=0,h=currLength-1, mid = 0;           
            while(l <= h)
            {
                mid = Math.Floor((l+h)/2);
                if(myarray[Convert.ToInt32(mid)] == value)
                {
                    Console.WriteLine("Value {0} found at index {1}", value, mid);
                    return;
                }
                else if(value > myarray[Convert.ToInt32(mid)])
                {
                    l = mid + 1;
                }
                else if(value < myarray[Convert.ToInt32(mid)])
                {
                    h = mid - 1;
                }
            }
            Console.WriteLine("Value not found in the array");
        }
        public void SearchBinaryRecursive(int value,double l, double h)
        {
            double mid = Math.Floor((l+h)/2);
            if(l<=h)
            {
                if(myarray[Convert.ToInt32(mid)] == value)
                {
                    Console.WriteLine("Value {0} found at index {1}", value, mid);
                }
                else if(value < myarray[Convert.ToInt32(mid)])
                {
                    SearchBinaryRecursive(value,l,h-1);
                }
                else 
                {
                    SearchBinaryRecursive(value,l+1,h);
                }
            }
            else
            {
                Console.WriteLine("Value not found in the array");
            }
        }
        public void Min()
        {
            int min = myarray[0];
            for(int i = 1; i < currLength; i++)
            {
                if(myarray[i] < min)
                    min = myarray[i];
            }
            Console.WriteLine("The Min value is {0}", min);
        }
        public void Max()
        {
            int max = myarray[0];

            for(int i = 1; i < currLength; i++)
            {
                if(myarray[i] > max)
                    max = myarray[i];
            }

            Console.WriteLine("The Max value is {0}", max);
        }
        public void Sum()
        {
            int sum = 0;
            for(int i = 0; i < currLength; i++)
            {
                sum+= myarray[i];
            }
            Console.WriteLine("The Sum of all array values is {0}", sum);
        }
        public void SumRecursive(int sum,int n)
        {
            if(n < currLength)
            {
                sum = sum + myarray[n];
                SumRecursive(sum,n+1);
            }
            else
            {
                Console.WriteLine("The Sum (Recursive) of all array values is {0}", sum);
            }
        }
        public void Avg()
        {
            int sum = 0;
            for(int i = 0; i < currLength; i++)
            {
                sum+= myarray[i];
            }
            Console.WriteLine("The Avg of all array values is {0}", sum/currLength);
        }
        public void ReverseWithAuxArray()
        {
            int[] auxarray = new int[sizeOfArray];

            for(long i=currLength-1,j=0; i>=0; i--,j++)
            {
                auxarray[j] = myarray[i];
            }

            for(int i = 0; i < currLength; i++)
            {
                myarray[i] = auxarray[i];
            }

            printArray(auxarray);
        }
        public void ReverseWithoutAuxArray()
        {
            for(long i =0, j=currLength-1; i<j;i++,j--)
            {
                int temp = myarray[i];
                myarray[i] = myarray[j];
                myarray[j] = temp;
            }
            printArray();
        }
        public void LeftRotate(int noOfRotations)
        {
            if(noOfRotations == 0)
            {
                return;
            }
            int t = myarray[0];
            for(long i = 1; i < currLength; i++)
            {   
                myarray[i-1] = myarray[i];
            }
            myarray[currLength-1] = t;

            LeftRotate(noOfRotations-1);
        }
        public void RightRotate(int noOfRotations)
        {
            if(noOfRotations == 0)
            {
                return;
            }
            int t = myarray[currLength-1];
            for(long i = currLength-2; i >= 0; i--)
            {   
                myarray[i+1] = myarray[i];
            }
            myarray[0] = t;

            RightRotate(noOfRotations-1);
        }
        public void InsertInASortedArray(int value)
        {
            if(sizeOfArray == currLength)
            {
                Console.WriteLine("Array is full");
                return;
            }
            long i = currLength-1;
            while(myarray[i] > value)
            {
                myarray[i+1] = myarray[i];
                i--;
            }
            myarray[i+1] = value;
            currLength++;
            printArray();
        }
        public void IsSortedArray(int[] array)
        {
            printArray(array);
            for(int i = 0; i < array.Length-1; i++)
            {
                if(array[i] > array[i+1])
                {
                    Console.WriteLine("NOT SORTED");
                    return;
                }                
            }

            Console.WriteLine("SORTED");
        }
        public void ArrangeNegativeOnLeftPositiveOnRight()
        {
            int[] array = new int[10] {-5,4,6,-6,7,8,-22,-33,-45,1};
            Console.WriteLine("========ArrangeNegativeOnLeftPositiveOnRight========");
            Console.WriteLine("========BEFORE========");
            printArray(array);
            int n = 0;
            int p = array.Length - 1;

            while(n < p)
            {
                while(array[n] < 0) { n++; }
                while(array[p] > 0) { p--; }

                if(n < p)
                {
                    int t = array[n];
                    array[n] = array[p];
                    array[p] = t;
                }
            }

            Console.WriteLine("========AFTER========");
            printArray(array);

        }
        public void MergeSortedArray(int[] a, int[] b)
        {
            int sizeA = a.Length;
            int sizeB = b.Length;
            int sizeC = sizeA + sizeB;

            int[] c = new int[sizeC];

            int p_A = 0;
            int p_B = 0;
            int p_C = 0;
            printArray(a);
            printArray(b);
            while(p_A < sizeA && p_B < sizeB)
            {
                if(a[p_A] > b[p_B])
                    c[p_C++] = b[p_B++];
                else   
                    c[p_C++] = a[p_A++];
            }

            for(;p_A < sizeA; p_A++)
            {
                c[p_C++] = a[p_A];
            }

            for(;p_B < sizeB; p_B++)
            {
                c[p_C++] = b[p_B];
            }
           
            printArray(c);

        }
    
        public void UnionArray(int[] a,int[] b)
        {
            //for sorted arrays 
            int sizeA = a.Length;
            int sizeB = b.Length;
            int sizeC = sizeA + sizeB;

            int[] c = new int[sizeC];

            int p_A = 0;
            int p_B = 0;
            int p_C = 0;
            printArray(a);
            printArray(b);

            while(p_A < sizeA && p_B < sizeB)
            {
                if(a[p_A] > b[p_B])
                    c[p_C++] = b[p_B++];
                else if (a[p_A] < b[p_B])  
                    c[p_C++] = a[p_A++];
                else
                {
                    c[p_C++] = a[p_A++];
                    p_B++;
                }    
            }

            for(;p_A < sizeA; p_A++)
            {
                c[p_C++] = a[p_A];
            }

            for(;p_B < sizeB; p_B++)
            {
                c[p_C++] = b[p_B];
            }

            printArray(c);
        }
    
        public void IntersectionArray(int[] a,int[] b)
        {
            //for sorted arrays 
            int sizeA = a.Length;
            int sizeB = b.Length;
            int sizeC = sizeA + sizeB;

            int[] c = new int[sizeC];

            int p_A = 0;
            int p_B = 0;
            int p_C = 0;
            printArray(a);
            printArray(b);

            while(p_A < sizeA && p_B < sizeB)
            {
                if(a[p_A] > b[p_B])
                    p_B++;
                else if (a[p_A] < b[p_B])  
                    p_A++;
                else
                {
                    c[p_C++] = a[p_A++];
                    p_B++;
                }    
            }

            printArray(c);
        }
    
        public void DifferenceArray(int[] a,int[] b)
        {
            //for sorted arrays 
            int sizeA = a.Length;
            int sizeB = b.Length;
            int sizeC = sizeA;

            int[] c = new int[sizeC];

            int p_A = 0;
            int p_B = 0;
            int p_C = 0;
            printArray(a);
            printArray(b);

            while(p_A < sizeA && p_B < sizeB)
            {
                if(a[p_A] < b[p_B])
                    c[p_C++] = a[p_A++];
                else if (b[p_B] < a[p_A])  
                    p_B++;
                else
                {
                    p_A++;
                    p_B++;
                }    
            }

            for(;p_A < sizeA; p_A++)
            {
                c[p_C++] = a[p_A];
            }

            printArray(c);
        }
    }
}