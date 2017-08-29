using System;
using System.Collections.Generic;

namespace binarysearchtree
{
    public class BST<T> : ICollection<T>
    {
        BSTNode root;
        IComparer<T> mComparer;
        int count;

        //ctor
        public BST()
        {
            count = 0;
            mComparer = Comparer<T>.Default;
            root = null;
        }
        //ctor with values
        public BST(IEnumerable<T> values) : this()
        {
            foreach (T item in values)
            {
                Add(item);
            }
        }
        public void insert(T item)
        {
            BSTNode node = new BSTNode(item);
            if (root != null)
            {
                BSTNode dest = root;
                while (dest != null)
                {
                    int result = mComparer.Compare(item, dest.Value);
                    if (result < 0)
                    {
                        if (dest.LesserChild != null)
                        {
                            dest = dest.LesserChild;
                        }
                        else
                        {
                            dest.LessChild = node;
                            node.Parent = dest;
                            break;
                        }
                    }
                    else
                    {
                        if (dest.GreaterChild != null)
                        {
                            dest = dest.GreaterChild;
                        }
                        else
                        {
                            dest.GreaterChild = node;
                            node.Parent = dest;
                            break;
                        }
                    }
                }
            }
            else
            {
                root = node;
            }
            count++;
        }
        public bool Contains(T item)
        {
            return (Find(item) != null);
        }
        protected IComparer<T> Comparer
        {
            get;set;
        }
        public int Count
        {
            get;
        }
        public IEnumerable<T> SortedTree
        {
            get
            {
                BSTNode prev = null;
                BSTNode current = root;
                BSTNode next = null;

                while (current != null)
                {
                    if ((prev == null) || (prev == current.Parent))
                    {
                        prev = current;
                        next = current.LesserChild;
                    }
                    if ((next == null) || (prev == current.LesserChild))
                    {
                        yield return current.Value; //yield subs a loop to return individual vals
                        prev = current;
                        next = current.GreaterChild;
                    }
                    if ((next == null) || (prev == current.GeaterChild))
                    {
                        prev = current;
                        next = current.Parent;
                    }
                    current = next;
                }
            }
        }
        public IEnumerable<T> PreSort
        {
            get
            {
                BSTNode prev = null;
                BSTNode current = root;
                BSTNode next = null;

                while (current != null)
                {
                    if ((prev == null) || (prev == current.Parent))
                    {
                        yield return current.Value;
                        prev = current;
                        next = current.LesserChild;
                    }
                    if ((next == null) || (prev == current.LesserChild))
                    {
                        prev = current;
                        next = current.GreaterChild;
                    }
                    if ((next == null) || (prev == current.GreaterChild))
                    {
                        prev = current;
                        next = current.Parent;
                    }
                    current = next;
                }
            }
        }
        public bool contains(T item)
        {
            return (Find(item) != null);
        }
        #region Helper Funcs
        BSTNode Find(T item)
        {
            BSTNode node = root;
            while (node != null)
            {
                int result = mComparer.Compare(item, node.Value);
                if (result == 0)
                {
                    return node;
                }
                else if (result < 0)
                {
                    node = node.LesserChild;
                }
                else
                {
                    node = node.GreaterChild;
                }
            }
            return null;
        }
        #endregion  

        private class BSTNode
        {
            T mValue;
            BSTNode mParent;
            BSTNode mLesserChild;
            BSTNode mGreaterChild;

            public BSTNode GreaterChild
            {
                get { return mGreaterChild; }
                set { mGreaterChild = value; }
            }
            public BSTNode LesserChild
            {
                get { return mLesserChild; }
                set { mLesserChild = value; }
            }
            public BSTNode Parent
            {
                get { return mParent; }
                set { mParent = value; }
            }
            public T Value
            {
                get { return mValue; }
                set { mValue = value; }
            }
            public BSTNode(T value)
            {
                mValue = value;
                mParent = mGreaterChild = mLesserChild = null;
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            BST<int> test = new BST<int>(new int[] { 12, 1, 8, 200, 657, 50, 2, 9, 13, 1024, 512, 768 });

            Console.WriteLine("'12' is " + (!test.Contains(12) ? "NOT " : "") + "in the collection.");
            Console.WriteLine("'10' is " + (!test.Contains(10) ? "NOT " : "") + "in the collection.");

            foreach (int val in test.SortedTree) Console.Write("{0} ", val);
            Console.WriteLine();
        }
    }
}