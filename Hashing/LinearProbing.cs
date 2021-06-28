namespace DataStructuresAndAlgo.Hashing
{
    public class LinearProbing
    {
        public int[] HTable;
        public int Hsize;

        public LinearProbing(int size)
        {
            Hsize = size;
            HTable = new int[Hsize];
        }

        public int HashFunction(int value)
        {
            return value % Hsize;
        }

        public int Probe(int key)
        {
            int i = 0;
            while (HTable[(key + i) % Hsize] != 0)
            {
                i++;
            }

            return key + 1;
        }


        public void Insert(int value)
        {
            int key = HashFunction(value);

            if (HTable[key] == 0)
            {
                HTable[key] = value;
                return;
            }

            key = Probe(key);

            HTable[key] = value;
        }

        public bool Search(int value)
        {
            int key = HashFunction(value);

            if (HTable[key] == value)
            {
                return true;
            }

            int i = 0;
            while (HTable[(key + i) % Hsize] != value)
            {
                //if the value is empty in a position in Htable that means the search value is not available
                // as we are inserting in a linear way 
                if (HTable[(key + i) % Hsize] == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
}