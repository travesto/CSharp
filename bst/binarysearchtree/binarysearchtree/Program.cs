using System;
using System.Collections.Generic;

namespace binarysearchtree
{
    public class Node<T> where T : System.IComparable
    {
        public T data;
        public Node<T> left, right;
        
        public Node(T data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
    public class Tree<T> where T : System.IComparable
    {
        Node<T> root;
        static int count = 0;
        public Tree() //ctor
        {
            root = null;
        }
        public Node<T> addNode(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (root == null)
            {
                root = newNode;
            }
            count++;
            return newNode;
        }
        public void insert(Node<T> root, Node<T> newNode) 
        {
            Node<T> temp;
            temp = root;
            
            if (newNode.data.CompareTo(temp.data) < 0)
            {
                if (temp.left == null)
                {
                    temp.left = newNode;
                }
                else
                {
                    temp = temp.left;
                    insert(temp, newNode);
                }
            }
            else if (newNode.data.CompareTo(temp.data) > 0)
            {
                if (temp.right == null)
                {
                    temp.right = newNode;
                }
                else
                {
                    temp = temp.right;
                    insert(temp, newNode);
                }
            }
        }
        public int contains(Tree<T> t, T value)
        {
            Node<T> node = t.root;
            int depth = 0;

            while (node != null)
            {
                int result = 0;
                //int result = depth.Compare(value, node.data);
                if (result == 0)
                {
                    return depth;
                }
            }
            return depth;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);
        }
    }
}