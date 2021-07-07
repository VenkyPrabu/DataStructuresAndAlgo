namespace DataStructuresAndAlgo.UnionFind
{
    public class UnionFindDS
    {
        //https://www.youtube.com/watch?v=KbFlZYCpONw&ab_channel=WilliamFiset
        //no of elements in the union find
        public int size;
        //to track the size of each of the components
        public int[] sz;
        //To point the parent of the i, 
        //id[i] points to the parent of i, 
        //if id[i] = i then i is a root node
        public int[] id;

        public int numOfComponents;

        public UnionFindDS(int n){
            size=n;
            sz=new int[size];
            id=new int[size];
            numOfComponents=size;
            for (int i=0;i<size;i++){
                sz[i]=1; // each component is originally of size 1
                id[i]=i; // link to itself initially (self root)
            }
        }

        public int Find(int p)
        {
            //find the root of the component
            int root = p;
            while(root != id[root])
            {
                root = id[root];
            }

            //path compression
            while(p != root)
            {
                int next = id[p];
                id[p] = root;
                p = next;
            }

            return root;
        }

        public bool IsConnected(int p,int q)
        {
            return Find(p) == Find(q);
        }

        public int ComponentSize(int p){
            return sz[Find(p)];
        }

        public int Size(){
            return size;
        }

        public int components()
        {
            return numOfComponents;
        }

        public void Union(int p, int q){
            
            int root1=Find(p);
            int root2=Find(q);

            if(root1 == root2){
                return;
            }
            if(sz[root1]<sz[root2]){
                sz[root2]=sz[root2]+sz[root1];
                id[root1]=root2;
            }else{
                sz[root1]=sz[root1]+sz[root2];
                id[root2]=root1;
            }
            numOfComponents--;
        }
    }
}