namespace DataStructuresAndAlgo.Practice.Sorting
{
    public class InsertionSort
    {
        public void main()
        {
                
        }

        public void sort(int[] arr)
        {
            int n = arr.Length;

            for(int i = 1; i < n; i++)
            {
                int x = arr[i];
                int j = i - 1;

                while(j >= 0 && arr[j] > x)
                {
                    arr[j+1] = arr[j];
                    j--;
                }

                arr[j+1] = x;
            }
        }
    }
}