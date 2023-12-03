namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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
                Element = element;
            }
        }

        private Node head;

        public int Count {get; private set;}

        public void Enqueue(T item)
        {
            if (head == null)
            {
                head = new Node(item);
                Count++;
                return;
            }
            var node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = new Node(item); 
            this.Count++;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            var oldHead = head;

            head = head.Next; 

            Count--;
            return oldHead.Element;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return head.Element;
        }

        public bool Contains(T item)
        {
            var node = this.head;            
            while (node != null)
            {
                if (item.Equals(node.Element))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}