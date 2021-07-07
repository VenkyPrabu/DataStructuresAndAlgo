using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Algorithms
{
    public class Knapsack
    {
        //https://dotnetcoretutorials.com/2020/04/22/knapsack-algorithm-in-c/
        public int capacity;
        public List<Item> items;

        public int[,] matrix;

        public int result;

        public Knapsack()
        {

        }

        public int SolveKnapsack(int capacity, List<Item> items)
        {
            this.capacity = capacity;
            this.items = items;
            this.matrix = new int[items.Count + 1, capacity + 1];
            int itemCount = this.items.Count;

            for (int i = 0; i <= itemCount; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        matrix[i, w] = 0;
                        continue;
                    }

                    var currentItemIndex = i - 1;
                    var cuurentItem = items[currentItemIndex];

                    if (cuurentItem.weight <= w)
                    {
                        matrix[i, w] = Math.Max(cuurentItem.value + matrix[i - 1, w - cuurentItem.weight]
                                        , matrix[i - 1, w]);
                    }
                    else
                        matrix[i, w] = matrix[i - 1, w];
                }
            }

            //to show which objects included

            int c = itemCount; int j = capacity;

            while (c > 0 && j > 0)
            {
                if (matrix[c, j] != matrix[c - 1, j])
                {
                    Console.WriteLine("Item :" + c + " is included");
                    j = j - items[c - 1].weight;
                }
                c--;
            }

            return matrix[itemCount, capacity];
        }


        public double FracKnapSack(Item[] items, int maxweight)
        {

            customComparer cmp = new customComparer();
            System.Array.Sort(items, cmp);

            double totalvalue = 0;
            int currentweight = 0;

            foreach (var item in items)
            {

                //check if full weight can be added
                if (currentweight + item.weight < maxweight)
                {
                    currentweight = currentweight + item.weight;
                    totalvalue = totalvalue + item.value;
                }
                else
                {
                    if (currentweight == maxweight)
                    {
                        break;
                    }
                    else
                    {
                        //add fraction
                        double fraction = (maxweight - currentweight) / (double)item.weight;
                        totalvalue = totalvalue + (fraction * (double)item.value);
                        currentweight = currentweight + (int)(fraction * (double)item.weight);
                    }
                }
            }
            return totalvalue;

        }

        public void main()
        {
            this.items = new List<Item>
                {
                    // new Item {value = 120, weight = 10},
                    // new Item {value = 100, weight = 20},
                    // new Item {value = 500, weight = 30},
                    new Item {value = 1, weight = 2},
                    new Item {value = 2, weight = 3},
                    new Item {value = 5, weight = 4},
                    new Item {value = 6, weight = 5},

                };
            this.capacity = 8;
            var kss = SolveKnapsack(capacity, items);
            Console.WriteLine(kss);

            //Console.WriteLine(ks(items.Count - 1, capacity));
        }
    }

    public class Item
    {
        public int weight { get; set; }
        public int value { get; set; }
    }

    public class customComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Item item1 = (Item)x;
            Item item2 = (Item)y;
            double ratio1 = (double)item1.value / (double)item1.weight;
            double ratio2 = (double)item2.value / (double)item2.weight;
            if (ratio1 < ratio2)//Descending
            {
                return 1;
            }
            else if (ratio1 == ratio2)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }


}