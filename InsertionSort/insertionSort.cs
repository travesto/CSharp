using System;

namespace Algorithm
{
    public class insertionSort
    {
        public static void print(int[] A, int size)
        {
           Console.Write(A[0]);
           for (int i = 1; i < size; i++)
           {
               Console.Write(", " + A[i]);
           }
           Console.WriteLine("\n");
           
        }
        public static void Main()
        {
            int[] A = new int[10] {5,7,2,3,6,0,9,1,8,4};
            int size = 10;

            //sort array
            Console.WriteLine("Initial Array\n");
            print(A, size);
            for (int i = 0; i < size; i++)
            {
                int pos = i;
                int value = A[pos];
                while (pos > 0 && value < A[pos-1])
                {
                    A[pos] = A[pos-1];
                    pos--;
                }
                A[pos] = value;

                Console.Write("Move the value " + A[pos] + " into place: ");
                print(A,size);
            }
            Console.WriteLine("Sorted Array");
            print(A,size);

        }
    }
}
