#include<cstddef> // includes NULL definition
#include <iostream>
using namespace std;

template <class T>
struct Stack {
   T*  data;	// array of values
   int size;	// size of array
   int top;	// index of value currently at top of Stack
};

template <class T>
void initialize(Stack<T> &s)
{
    s.data = new T[2];
    s.size = 2;
    s.top = 0;
}

template <class T>
void destroy(Stack<T> &s)
{
    delete [] s.data;
    s.data = NULL;
}
template <class T>
bool isEmpty(Stack<T> s)
{
    if (s.top == 0)
    {
        return true;
    }
    return false;
}   
template <class T>
void push(Stack<T> &s, T blerg)
{
    
    if (s.top == s.size)
    {
        T* temp = new T [s.size*2];
        for (int a = 0; a < s.size; a++)
        {
            temp[a] = s.data[a];
            //cout << "Temp = " << temp[a] << ", ";
        }
        delete [] s.data;
        s.data = temp;
        s.size *= 2;        
        temp = NULL;
    }
    s.data[s.top] = blerg;
    s.top++;
    
}
template <class T>
T    pop(Stack<T> &s)
{
    T pop = s.data[s.top-1];
    s.top--;
    //s.size--;
    return pop;
}