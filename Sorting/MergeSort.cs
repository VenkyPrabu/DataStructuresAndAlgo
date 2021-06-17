using System;

namespace DataStructuresAndAlgo.Sorting
{
    public class MergeSort
    {
        //TODO: Merge Iterative again
        public void main()
        {
            //int[] a = new int[11] { 3, 7, 9, 10, 6, 5, 12, 4, 11, 2, 20 };
            //int[] a = new int[3] { 3, 2, 9};
            int[] a = new int[7] { 3, 2, 9, 11, 6, 5, -1};
            Print(a);
            MergeIterative(a,a.Length);
            //MergeRecursive(a,0,a.Length-1);

            Print(a);
        }

        public void Print(int[] a)
        {
            Console.WriteLine("=============PRINT============");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();
        }

        public void MergeIterative(int[] a, int n)
        {
            int p,l,h,m,i;

            for(p=2; p<=n; p=p*2)
            {
                for(i=0; i+p-1<n;i=i+p)
                {
                    l=i;
                    h=i+p-1;
                    m = (l+h)/2;
                    Merge(a,l,m,h);
                }

                if(n-i > p/2)
                {
                    l = i;
                    h = i + p -1;
                    m = (l+h)/2;
                    Merge(a,l,m,n-1);
                }
            }

            if(p/2 <n)
            {
                Merge(a,0,(p/2)-1,n-1);
            }
        }
        
        public void MergeRecursive(int[] a, int l, int h)
        {
            if(l<h)
            {
                int m = (l+h)/2;
                MergeRecursive(a,l,m);
                MergeRecursive(a,m+1,h);
                Merge(a,l,m,h);
            }
        }
        public void Merge(int[] a, int l, int m, int h)
        {
            int i = l,j = m+1,k = l;
            int[] b = new int[100];

            while(i<=m && j<=h)
            {
                if(a[i] < a[j])
                    b[k++] = a[i++];
                else    
                    b[k++] = a[j++];
            }

            for(;i<=m;i++)
            {
                b[k++] = a[i];
            }

            
            for(;j<=h;j++)
            {
                b[k++] = a[j];
            }

            for(int c = l; c <=h; c++)
            {
                a[c] = b[c];
            }
        }
    }
}