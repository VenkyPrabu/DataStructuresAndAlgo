using System;

namespace DataStructuresAndAlgo.Algorithms
{

    public class Job
    {
        public int JobId;
        public int Profit;
        public int Deadline;

        public Job(int jobId, int profit, int deadline)
        {
            JobId = jobId;
            Profit = profit;
            Deadline = deadline;
        }
    }
    public class JobSequencing
    {
        public void main()
        {
            Job[] jobs = new Job[]{
                new Job(1,20,4),
                new Job(2,10,1),
                new Job(3,40,1),
                new Job(4,30,1),
            };
            var sequence = Schedule(jobs, 4);
            PrintSequence(sequence);

            Job[] jobs1 = new Job[]{
            new Job(1, 15,9), new Job(2, 2, 2),
                new Job(3, 18, 5), new Job(4, 1, 7),
                new Job(5, 25, 4), new Job(6, 20, 2),
                new Job(7, 8, 5), new Job(8, 10, 7),
                new Job(9, 12, 4), new Job(10, 5, 3)};
            sequence = Schedule(jobs1, 10);
            PrintSequence(sequence);
        }


        public int[] Schedule(Job[] jobs, int T)
        {
            int n = jobs.Length;

            System.Array.Sort(jobs, (a, b) => b.Profit.CompareTo(a.Profit));

            int[] slot = new int[T];

            for (int i = 0; i < T; i++)
            {
                slot[i] = -1;
            }

            foreach (var job in jobs)
            {
                for (int j = job.Deadline - 1; j >= 0; j--)
                {
                    if (slot[j] == -1)
                    {
                        slot[j] = job.JobId;
                        break;
                    }
                }
            }

            return slot;

        }

        public void PrintSequence(int[] sequence)
        {
            foreach (var item in sequence)
            {
                if (item != -1)
                {
                    Console.Write(item);
                    Console.Write("-->");
                }
            }
            Console.WriteLine();
        }
    }
}