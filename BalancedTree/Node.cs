using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTree
{
    public class Node
    {
        public static readonly bool RED = true;
        public static readonly bool BLACK = false;

        public Key Key { get; set; }
        public Value Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public bool Color { get; set; }
        public int N { get; set; }

        public Node(Key key, Value value, int size, bool color)
        {
            Key = key;
            Value = value;
            N = size;
            Color = color;
        }
    }

    public class Key : IComparable<Key>
    {
        public static bool operator < (Key e1, Key e2)
        {
            return e1.CompareTo(e2) < 0;
        }

        public static bool operator >(Key e1, Key e2)
        {
            return e1.CompareTo(e2) > 0;
        }

        public int CompareTo(Key other)
        {
            throw new NotImplementedException();
        }
    }

    public class Value
    {
    }
}
