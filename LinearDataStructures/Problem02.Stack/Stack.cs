namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public Node(T element)  
            {
            }
        }

        private Node top;

        public int Count {get; set;}

        public void Push(T item)
        {
            var node = new Node(item, this.top);
            top = node;
            Count++;
        }

        public T Pop()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }

            var oldTop = top;
            top = oldTop.Next;


            Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
            return this.top.Element;
        }

        public bool Contains(T item)
        {
            var node = this.top;
            while (node != null)
            {
                var element = node.Element;
                if (item.Equals(element))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.top;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}