using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTree
{
    public class RedBlackBST
    {
        private Node root { get; set; }

        public bool IsRed(Node x)
        {
            if (x == null) return false;
            return x.Color == Node.RED;
        }

        public void Put(Key key, Value value)
        {
            root = Put(root, key, value);
            root.Color = Node.BLACK;
        }

        public Node Put(Node h, Key key, Value value)
        {
            if (h == null)
                return new Node(key, value, 1, Node.RED);

            if (key < h.Key)
                h.Left = Put(h.Left, key, value);

            if (key > h.Key)
                h.Right = Put(h.Right, key, value);

            if (key == h.Key)
                h.Value = value;

            if (IsRed(h.Right) && !IsRed(h.Left))
                h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left))
                h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right))
                FlipColors(h);

            return h;
        }

        public void FlipColors(Node h)
        {
            h.Color = Node.RED;
            h.Left.Color = Node.BLACK;
            h.Right.Color = Node.BLACK;
        }

        public Node RotateLeft(Node h)
        {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = Node.RED;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        public Node RotateRight(Node h)
        {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = Node.RED;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        //TODO: check realization
        public int Size(Node x)
        {
            if (x.Left == null && x.Right == null)
                return 1;

            return 1 + Size(x.Left) + Size(x.Right);
        }
    }
}
