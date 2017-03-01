#include <iostream>
#include <iomanip>
using namespace std;

int FindString(string list[],int n,string target)
{
    for (int i=0; i < n; i++)
       if (list[i]==target)
           return i;
    return -1;
}

void Sort(string list[],string list2[],int n)
{
    for (int i=0; i < n-1; i++) {
       int j = i;
       for (int k=j+1; k < n; k++)
           if (list[k] < list[j])
              j = k;
       string t = list[j]; 
       list[j] = list[i]; 
       list[i] = t;
       t = list2[j];
       list2[j] = list2[i];
       list2[i] = t;
    }
}

int main()
{
    cout << "This program prints parent-child pairs." << endl;
    cout << "Enter parents and children below, use 'quit' to stop." << endl;
    
    string child[100];
    string parent[100];
    int count = 0;

    while (true) {
       cout << "Parent: ";
       string new_parent,children,name;
       getline(cin,new_parent);    
       if (new_parent == "quit") break;
       
        int i = FindString(child,count,new_parent);
        if (i < 0) {
            child[count] = new_parent;
            parent[count] = "";
            count++;
        }
       
       cout << "Children of " << new_parent << ": ";
       getline(cin,children);
       stringstream ss(children);
       while (ss >> name) {
           i = FindString(child,count,name);
           if (i < 0) {
               child[count] = name;
               i = count++;
           }
           parent[i] = new_parent;
       }
    }
    
    Sort(child,parent,count);
    
    cout << endl;
    cout << "Child    Parent" << endl;
    cout << "-----    ------" << endl;
    for (int i=0; i < count; i++)
       cout << setw(9) << left << child[i] << parent[i] << endl;
}
