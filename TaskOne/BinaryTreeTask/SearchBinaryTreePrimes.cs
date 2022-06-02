using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BinaryTreeTask
{
    class SearchBinaryTreePrimes
    {
        private BinaryTreeNode _root;
        private int[] _timeStats;
        public BinaryTreeNode Root { get => _root; }
        public SortedSet<int> PrimeNumbers { get; }

        delegate void TraverseMethods(BinaryTreeNode node);
        private TraverseMethods[] _traverseMethods;


        public SearchBinaryTreePrimes()
        {
            PrimeNumbers = new SortedSet<int>();
            _root = null;
            _traverseMethods = new TraverseMethods[]
            {
                TraverseInOrder, TraversePreOrder, TraverseLevelOrder
            };
            _timeStats = new int[_traverseMethods.Length];
        }

        public void Insert(int value)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(value);
            
            if (_root == null) 
                _root = newNode;
            else
            {
                BinaryTreeNode currentNode = _root;
                BinaryTreeNode parentNode;
                while (true)
                {
                    parentNode = currentNode;

                    if (value == currentNode.Value)
                        return;

                    if (value < currentNode.Value)
                    {
                        currentNode = currentNode.Left;
                        if (currentNode == null)
                        {
                            parentNode.Left = newNode;
                            return;
                        }

                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        if(currentNode == null)
                        {
                            parentNode.Right = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public void GenerateTree(int amount)
        {
            Random random = new Random();
            for (int i = 0; i < amount; i++)
                Insert(random.Next(1, amount));
        }

        private bool IsPrime(int value )
        {
            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }

        public int[] GetTimeStats()
        {
            Stopwatch timer = new Stopwatch();
            for(int i = 0; i < _traverseMethods.Length; i++)
            {
                PrimeNumbers.Clear();
                timer.Start();
                _traverseMethods[i](_root);
                timer.Stop();
                _timeStats[i] = (int)timer.ElapsedTicks;
                timer.Reset();
            }
            return _timeStats;
        }

        private void TraverseInOrder(BinaryTreeNode node)
        {
            if(node != null)
            {
                TraverseInOrder(node.Left);

                if (IsPrime(node.Value))
                    PrimeNumbers.Add(node.Value);

                TraverseInOrder(node.Right);
            }
        }

        private void TraverseLevelOrder(BinaryTreeNode node)
        {
            if (node == null)
                return;

            Queue<BinaryTreeNode> tempQueueNodes = new Queue<BinaryTreeNode>();
            tempQueueNodes.Enqueue(node);

            while (tempQueueNodes.Count > 0)
            {
                BinaryTreeNode currentNode = tempQueueNodes.Dequeue();

                if (IsPrime(currentNode.Value))
                    PrimeNumbers.Add(currentNode.Value);

                if (currentNode.Left != null) tempQueueNodes.Enqueue(currentNode.Left);
                if (currentNode.Right != null) tempQueueNodes.Enqueue(currentNode.Right);
            }
        }

        private void TraversePreOrder(BinaryTreeNode node)
        {
            if (node != null)
            {
                if (IsPrime(node.Value))
                    PrimeNumbers.Add(node.Value);
                
                TraversePreOrder(node.Left);
                TraversePreOrder(node.Right);
            }
        }

        public string GetStringPrimes()
        {
            string result = null;
            foreach(var item in PrimeNumbers)
            {
                result += Convert.ToString(item) + " ";
            }
            return result;
        }
    }
}
