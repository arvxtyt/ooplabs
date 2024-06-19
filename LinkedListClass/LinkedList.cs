using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace LinkedListClass
{
    public class LinkedList : IEnumerator, IEnumerable
    {
        private Node? head;
        private Node? current;
        private bool MoveNextFlag = true;

        public void Add(double value)
        {
            if (head is null)
            {
                head = new Node(value);
            }
            else
            {
                var newNode = new Node(value);
                newNode.child = head;
                head = newNode;
            }
            Reset();
        }

        public void Clear()
        {
            head = null;
            current = null;
        }

        public void Delete(int index)
        {
            if (index == 0)
            {
                Delete();
            }
            else
            {
                var headCopy = head;
                for (int i = 0; i < index - 1; i++)
                {
                    head = head!.child;
                }

                head!.child = head!.child!.child;
                head = headCopy;
            }
        }

        public void Delete()
        {
            head = head!.child;
        }

        public Node Current { get { return current!; } }
        public Node Head { get { return head!; } }

        public int Length
        {
            get
            {
                if (head is null)
                {
                    return 0;
                }

                int counter = 0;
                var headCopy = head;
                while (headCopy!.child is not null)
                {
                    headCopy = headCopy.child;
                    counter++;
                }

                return counter + 1;
            }
        }

        public virtual string ShowList()
        {
            var accum = new StringBuilder("");
            var headCopy = head;
            while (head is not null)
            {
                accum.Append(head.Value + "->");
                head = head.child;
            }
            head = headCopy;

            return accum.ToString();
        }

        object IEnumerator.Current => Current;

        public double GetSumOfElementsGreaterThanValue(double value)
        {
            var sum = 0.0;
            foreach (Node node in this)
            {
                if (node.Value > value)
                {
                    sum += node.Value;
                }
            }

            return sum;
        }

        public LinkedList GetLinkedListOfElementsLessThanAverage()
        {
            var avg = 0.0;
            foreach (Node node in this)
            {
                avg += node.Value;
            }

            avg /= Length;

            var newLinkedList = new LinkedList();

            foreach (Node node in this)
            {
                if (node.Value < avg)
                {
                    newLinkedList.Add(node.Value);
                }
            }

            return newLinkedList;
        }

        public void RemoveElementsOnEvenPositions()
        {
            for (int i = 1; i < Length; i += 1)
            {
                Delete(i);
            }
        }

        public bool FindFirstElementGreaterThanAverage(out double result)
        {
            var avg = 0.0;
            result = 0;
            var res = false;
            foreach (Node node in this)
            {
                avg += node.Value;
            }

            avg /= Length;

            foreach (Node node in this)
            {
                if (node.Value > avg)
                {
                    result = node.Value;
                    res = true;
                    break;
                }
            }

            return res;
        }

        public bool MoveNext()
        {
            if (current is null || current.child is null)
            {
                return false;
            }

            if (MoveNextFlag)
            {
                MoveNextFlag = false;
                return true;
            }

            current = current.child;
            
            return true;
        }

        public void Reset()
        {
            MoveNextFlag = true;
            current = head;
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }
    }
}
