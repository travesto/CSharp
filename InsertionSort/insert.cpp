// Implementation of insertion sort
#include <iostream>
using namespace std;

void print(int A[], int size)
{
    cout << A[0];
    for( int i = 1; i < size; i++ )
        cout << ", " << A[i];
    cout << endl;
}

int main()
{
    int A[10] = {5,7,2,3,6,0,9,1,8,4};
    int size = 10;
    
    // Sort array
    // Start at second element, then place each on in relative order
    cout << "\nINITIAL ARRAY\n";
    print(A,size);
    cout << endl;
    for( int i = 1; i < size; i++ )
    {
        int pos = i;
        int value = A[pos];
        while( pos > 0 && value < A[pos-1] ) 
        {
            A[pos] = A[pos-1];
            pos--;
        }
        A[pos] = value;
        
        cout << "Move the value " << A[pos] << " into place: ";
        print(A,size);
    }

    cout << "\nSORTED ARRAY\n";
    print(A,size);
}