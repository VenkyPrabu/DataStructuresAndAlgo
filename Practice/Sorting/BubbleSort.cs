namespace DataStructuresAndAlgo.Practice.Sorting
{
    public class BubbleSort
    {
        public void main()
        {

        }

        public int[] sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int x = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = x;
                    }
                }
            }

            return arr;
        }
    }

}