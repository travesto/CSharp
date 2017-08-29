using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("This program prints parent-child pairs.\nEnter parents and children below, use 'quit' to stop.");
            string[] child = new string[100];
            string[] parent = new string[100];
            int parChi = 0, total = 0, count = 0, extra;
            bool orphanAnnie = true;
            string pHold, cHold, min, parent_min;

            Console.Write("Parent: ");
            pHold = Console.ReadLine();
            while (pHold != "quit")
            {
                parChi = 0;
                Console.Write("How many children does " + pHold + " have?");
                parChi = int.Parse(Console.ReadLine());
                Console.WriteLine();
                total += parChi;
                Console.WriteLine("Children of " + pHold + ": ");
                for (; count < total; count++)
                {
                    cHold = Console.ReadLine();
                    parent[count] = pHold;
                    child[count] = cHold;
                }
                Console.Write("Parent: ");
                pHold = Console.ReadLine();
            }
            for (int i = 0; i < total; i++)
            {
                orphanAnnie = true;
                for (int q = 0; q < total; q++)
                {
                    if (parent[i] == " ")
                    {
                        orphanAnnie = false;
                    }
                    if (parent[i] == child[q])
                    {
                        orphanAnnie = false;
                    }
                }
                if (orphanAnnie == true)
                {
                    child[total] = parent[i];
                    parent[total] = " ";
                    total++;
                }
            }
            for (int k = 0; k < total; k++)
            {
                min = child[k];
                parent_min = parent[k];
                extra = k;
                for (int i = 0; i < total; i++)
                {
                    if (string.Compare(child[i], min) < 0)
                    {
                        min = child[i];
                        parent_min = parent[i];
                        extra = i;
                    }
                }
                child[extra] = child[k];
                parent[extra] = parent[k];
                child[k] = parent_min;
            }
            Console.Write("\n" + String.Format("{0, -9:D", "Child") + "Parent\n");
            Console.Write(String.Format("{0, -9:D", "----") + "------\n");
            for (int i = 0; i < total; i++)
            {
                Console.Write(String.Format("{0, -9:D", child[i] + parent[i] + "\n"));
            }

        }
    }
}
