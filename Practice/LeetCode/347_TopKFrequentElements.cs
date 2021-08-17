using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class TopKFrequentElements
    {
        public static Dictionary<int, int> count;
        public static int[] unique;
        public static int maxFreq;

        public void main()
        {
            //var r = TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);

            var  l = new List<int>();
            l.Add(1);
            l.Add(1);
            l.Add(1);
            l.Add(2);
            l.Add(2);
            l.Add(3);

            var r = find_top_k_frequent_elements(l,2);
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            count = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!count.ContainsKey(nums[i]))
                {
                    count.Add(nums[i], 1);
                }
                else
                {
                    count[nums[i]]++;
                }
            }

            int n = count.Count;
            unique = new int[n];
            int j = 0;

            foreach (var a in count)
            {
                unique[j] = a.Key;
                j++;
            }

            quickSelect(0, n - 1, n - k);
            int[] b = new int[k];

            System.Array.Copy(unique, n - k, b, 0, k);

            return b;

        }

        public static void quickSelect(int l, int r, int k_smallest)
        {
            if (l == r)
                return;

            //select a random index    
            int p_index = new Random().Next(l, r);

            p_index = partition(l, r, p_index);


            if (k_smallest == p_index)
            {
                return;
            }
            else if (k_smallest < p_index)
            {
                quickSelect(l, p_index - 1, k_smallest);
            }
            else
            {
                quickSelect(p_index + 1, r, k_smallest);
            }

        }

        public static int partition(int l, int h, int p_index)
        {
            int p_freq = count[unique[p_index]];

            swap(p_index, h);

            int store_index = l;

            for (int i = l; i <= h; i++)
            {
                if (count[unique[i]] < p_freq)
                {
                    swap(store_index, i);
                    store_index++;
                }
            }

            swap(store_index, h);

            return store_index;


        }

        public static void swap(int a, int b)
        {
            int x = unique[a];
            unique[a] = unique[b];
            unique[b] = x;
        }

        //method 2
        public static List<int> find_top_k_frequent_elements(List<int> arr, int k)
        {

            if (arr.Count <= k) return arr;

            var map = BuildFreqMap(arr);

            //Freq -> list<int> with that freq;
            var tmpFreqTable = PopulateFrequencyTable(map);

            var result = new List<int>();
            for (int i = tmpFreqTable.Length - 1; i >= 0; i--)
            {
                    if (k == 0) break;
                    result.Add(tmpFreqTable[i]);
                    k--;
            }

            return result;


        }

        public static Dictionary<int, int> BuildFreqMap(List<int> arr)
        {
            maxFreq = 0;
            var map = new Dictionary<int, int>();
            foreach (var n in arr)
            {
                if (!map.ContainsKey(n))
                {
                    map[n] = 1;
                }
                else
                {
                    map[n] += 1;
                }
                maxFreq = Math.Max(maxFreq, map[n]);
            }
            return map;
        }

        public static int[] PopulateFrequencyTable(Dictionary<int, int> map)
        {

            var ret = new int[maxFreq + 1];
            // for (int i = 0; i < ret.Length; i++)
            // {
            //     ret[i] = new List<int>();
            // }

            foreach (var kvp in map)
            {
                ret[kvp.Value] = kvp.Key;
            }
            return ret;
        }
    }
}