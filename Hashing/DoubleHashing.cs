namespace DataStructuresAndAlgo.Hashing
{
    public class DoubleHashing
    {
        public int[] HTable;
        public int Size;
        public int Prime;

        public DoubleHashing(int size)
        {
            Size = size;
            HTable = new int[Size];
            Prime = 7;
        }


        public int HashFunction(int value)
        {
            return value % Size;
        }

        public int PrimeHashFunction(int value)
        {
            return Prime - (value % Size);
        }

        public int Probing(int value)
        {
            int index1 = HashFunction(value);
            int index2 = PrimeHashFunction(value);
            int i = 0;
            while (HTable[(index1 + i * (index2)) % Size] != 0)
            {
                i++;
            }

            return (index1 + i * (index2)) % Size;
        }

        public void Insert(int value)
        {
            int key = HashFunction(value);
            if (HTable[key] == 0)
            {
                HTable[key] = value;
                return;
            }

            key = Probing(value);
            HTable[key] = value;
            return;
        }

        public bool Search(int value)
        {
            int key = HashFunction(value);
            if (HTable[key] == value)
            {
                return true;
            }
            int i = 0;
            int index1 = HashFunction(value);
            int index2 = PrimeHashFunction(value);
             while(HTable[(index1+(i*index2))%Size] != value){
                if (HTable[(index1+(i*index2))%Size] ==0){
                    return false;
                }
                i++;
            }
            return true;


        }
    }
}