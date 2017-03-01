using System.IO;
using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    class maze
    {
        public static char[] StringToArr(string input)
        {
            int temp = input.Length;
            char[] arr = input.ToCharArray(0, temp);
            return arr;
        }
        public static string RemoveWhitespace(string input)
        {
          return input = string.Join("", input.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
        public static void Main(string[] args)
        {
            int[] maze = new int[10000];
            string path="";
            Stack<int> points = new Stack<int>();
            int finished = 0, p, width=0;
            
            //get file location
            string file = Console.ReadLine();
            //read file to char array
            string text = System.IO.File.ReadAllText(file);
            
            text = RemoveWhitespace(text);
            // Console.Write(text+"\n");
            //convert string to char arr
            char[] readText = StringToArr(text);
            
                width = Convert.ToInt32(readText[0]);
                width -= 48;
                // assign values
                for (int i = 0; i < (width*width); i++)
                {
                    // Console.WriteLine(readText[i]);
                    // Console.Write(i);
                    if (readText[i] == 'X')
                    {
                        maze[i] = -1;
                    }
                    else if (readText[i] == '.')
                    {
                        maze[i] = 20000;
                    }
                    else if (readText[i] == 'S')
                    {
                        maze[i] = 0;
                        points.Push(i);
                        // Console.WriteLine("i= " + i);
                    }
                    else if (readText[i] == 'F')
                    {
                        maze[i] = 20000;
                        finished = i;
                    }
                }
                // p = points.Pop();
                // Console.WriteLine("\np = " + p);
                // points.Push(p);
                
                //find a path
                while (points.Count > 0)
                {
                    p = points.Pop();
                    {
                        if (maze[p]+1 < maze[p+1])
                        {
                            //update path length in maze
                            maze[p+1] = maze[p]+1;
                            points.Push(p+1);
                        }
                        if (maze[p]+1 < maze[p-1])
                        {
                            //update path length in maze
                            maze[p-1] = maze[p]+1;
                            points.Push(p-1);
                        }
                        if (maze[p]+1 < maze[p+width])
                        {
                            //update path length in maze
                            maze[p+width] = maze[p]+1;
                            points.Push(p+width); 
                        }
                        if (maze[p]+1 < maze[p-width])
                        {
                            //update path length in maze
                            maze[p-width] = maze[p]+1;
                            points.Push(p-width);
                        }
                    }
                }
                
                //determine output
                if (maze[finished] == 20000)
                {
                    Console.WriteLine("No path.");
                }
                else if (maze[finished] < 20000)
                {
                    int temp = finished;
                    while (maze[temp] != 0)
                    { 
                            if (maze[temp+1] == maze[temp] -1)
                            {
                                path += 'W';
                                temp += 1;
                            }
                            else if (maze[temp-1] == maze[temp] -1)
                            {
                                path += 'E';
                                temp -= 1;
                            }
                            else if (maze[temp+width] == maze[temp] -1)
                            {
                                path += 'N';
                                temp += width;
                            }
                            else if (maze[temp-width] == maze[temp] -1)
                            {
                                path += 'S';
                                temp -= width;
                            }                   
                    }
                Console.WriteLine("\n" + path); 
                }
        }
    }

}
