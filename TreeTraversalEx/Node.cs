namespace TreeTraversalEx
{
    class Node
    {
        public char? Value;
        public Node Left;
        public Node Right;

        public Node(char? v)
        {
            Value = v;
            Left = null;
            Right = null;
        }
    }
}