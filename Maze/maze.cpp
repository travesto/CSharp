#include <iostream>
#include <fstream>
#include "stack.h"
using namespace std;

int main()
{
    ifstream fin;
    int maze[100000]; //how to we predetermine the size of the array? Wouldn't a string be better?
    char hold[10000];
    string file, path;
    Stack<int> points;
    int finished, p, width;
    initialize(points);
    
    cin >> file;
    fin.open(file.c_str()); //read maze and assign values
    {
        fin >> width;
        cout << endl << width;
        for (int i = 0; i < (width*width); i++)
        {
            fin >> hold[i];
            cout << i << hold[i] << endl;
            if (hold[i] == 'X')
            {
                maze[i] = -1;
            }
            else if (hold[i] == '.')
            {
                maze[i] = 20000;
            }
            else if (hold[i] == 'S')
            {
                maze[i] = 0;
                push(points, i);
                cout << "i = " << i << endl;
            }
            else if (hold[i] == 'F')
            {
                maze[i] = 20000;
                finished = i;
            }
        }
        p = pop(points);
        cout << "p = " << p << endl;
        push(points, p);
        
        //find a path
        while (!isEmpty(points))
        {
            p = pop(points);
            {
                if (maze[p]+1 < maze[p+1])
                {
                    //update path length in maze
                    maze[p+1] = maze[p]+1;
                    push(points, p+1);
                }
                if (maze[p]+1 < maze[p-1])
                {
                    //update path length in maze
                    maze[p-1] = maze[p]+1;
                    push(points, p-1);
                }
                if (maze[p]+1 < maze[p+width])
                {
                    //update path length in maze
                    maze[p+width] = maze[p]+1;
                    push(points, p+width); 
                }
                if (maze[p]+1 < maze[p-width])
                {
                    //update path length in maze
                    maze[p-width] = maze[p]+1;
                    push(points, p-width);
                }
            }
        }
        //determine output
        if (maze[finished] == 20000)
        {
            cout << "No path.";
        }
        else if (maze[finished] < 20000)
        {
           int temp = finished;
           while (maze[temp] != 0)
           { 
                if (maze[temp+1] == maze[temp] -1)
                {
                    path = 'W' + path;
                    temp = temp + 1;
                }
                else if (maze[temp-1] == maze[temp] -1)
                {
                    path = 'E' + path;
                    temp = temp - 1;
                }
                else if (maze[temp+width] == maze[temp] -1)
                {
                    path = 'N' + path;
                    temp = temp + width;
                }
                else if (maze[temp-width] == maze[temp] -1)
                {
                    path = 'S' + path;
                    temp = temp - width;
                }                   
           }
           cout << path; 
        }
    }
    fin.close();
    destroy(points);
}