﻿using System;

namespace Parents
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			string[] parent = new string[100]; 
			string[] children = new string[100];
			string parent_hold, child_hold;
			int parentChildren = 0, total_children = 0, iterator = 0;
		 	bool orphan = true;
            int hold;
            string min, parent_min;

            Console.Write("This program prints parent-child pairs.\n");
			Console.Write("Enter parents and children below, use 'quit' to stop.\n");

			Console.Write("Parent: ");

			parent_hold = Console.ReadLine();

			while (parent_hold != "quit")
		    {
				parentChildren = 0;
				Console.Write("How many children does " + parent_hold + " have? ");
				parentChildren = int.Parse(Console.ReadLine()); ;
				Console.Write("\n");
				total_children += parentChildren;
				Console.Write("Children of " + parent_hold + ": \n");
				for (; iterator < total_children; iterator++)
		        {
					child_hold = Console.ReadLine();
		            parent[iterator] = parent_hold;
		            children[iterator] = child_hold;
		        }
				Console.Write("Parent: ");
				parent_hold = Console.ReadLine();
		    }



			for (int x = 0; x < total_children; x++)
		    {
		        orphan = true;
		        for (int y = 0; y < total_children; y++)
		        {
		            if (parent[x] == " ")
		                orphan = false;
		            if (parent[x] == children[y])
		                orphan = false;
		        }
		        if (orphan == true)
		        {
		            children[total_children] = parent[x];
		            parent[total_children] = " ";
		            total_children++;
		        }
		    }

		    for (int x = 0; x < total_children-1; x++)
		    {
		        min = children[x];
		        parent_min = parent[x];
		        hold = x;
		        for (int y = x+1; y < total_children; y++)
		        {
					if (string.Compare(children[y], min) < 0)
		            {
		                min = children[y];
		                parent_min = parent[y];
		                hold = y;
		            }
		        }
		        children[hold] = children[x];
		        parent[hold] = parent[x];
		        children[x] = min;
		        parent[x] = parent_min;
		    }

			Console.Write("\n" + String.Format("{0,-9:D}", "Child") + "Parent\n");
			Console.Write(String.Format("{0,-9:D}","-----") + "------\n");
		    for (int y = 0; y < total_children; y++)
		    {
				Console.Write(String.Format("{0,-9:D}",children[y]) + parent[y] + "\n");
		    }

		}
	}
}