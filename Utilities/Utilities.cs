using System;

namespace DataStructuresAndAlgo.Utilities
{
    public class Utilities
    {
        public static void PrintArray(int[] list)
        {
            foreach (var item in list)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }
    }
}