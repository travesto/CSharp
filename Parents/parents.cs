using System;

namespace ConsoleApplication
{
    public class Program
    {
        public struct parentChild
        {
            public string parent;
            public string child;

        }
        public static int findString(string[] list, int x, string target)
        {
            for (int i = 0; i < x; i++)
            {
                if (list[i] == target)
                {
                    return i;
                }
                return -1;
            }
        }
        public static void sort(string[] list, string[] list2, int x)
        {
            for (int i = 0; i < x-1; i++)
            {
                int y = x;
                for (int z = y + 1; z < x; z++)
                {
                    if (list[z] < list[y])
                    {
                        y=z;
                    }
                }
                string t = list[y];
                list[y] = list[x];
                list[x] = t;
                t = list2[y];
                list2[y] = list2[i];
                list2[x] = t;
            }
        }
        public static void Main(string[] args)
        {
            
            Console.WriteLine("This program prints parent-child pairs.\nEnter parents and children below, use 'quit' to stop.");
            string[] child = new string[100];
            string[] parent = new string[100];
            int count  = 0;

            while (true)
            {
                Console.Write("Parent: ");
                string new_parent,child,name;
                {
                    if (new_parent == "quit")
                    {
                        break;
                    }
                    int i = findString(child,count,new_parent);
                    if (i < 0)
                    {
                        child[count] = new_parent;
                        parent[count] = "";
                        count++;
                    }
                    Console.Write("Children of " + new_parent + ": ");
                    child = Console.ReadLine();
                    while(true)
                    {
                        i = findString(child, count, name);
                        if (i < 0)
                        {
                            child[count] = name;
                            i = count++;
                        }
                        parent[i] = new_parent;
                    }

                }
            }
            sort(child,parent,count);
            Console.WriteLine();
            Console.Write("Child    Parent\n");
            Console.Write("-----    ------\n");
            for (int i = 0; i < length; i++)
            {
                
            }
        }
    }
}
