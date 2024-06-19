using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListClass
{
    public class Node
    {
        public double Value { get; set; }

        public Node? child;

        public Node(double value)
        {
            Value = value;
        }
    }
}
