namespace Lists
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }

        public Node(T data, Node<T> nodeNext)
        {
            Data = data;
            Next = nodeNext;
        }
    }
}
