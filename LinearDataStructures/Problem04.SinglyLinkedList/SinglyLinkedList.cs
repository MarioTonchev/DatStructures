namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item, head);
            this.head = node;
            Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node(item);
            if (head == null)
            {
                head = node;
            }
            else
            {
                var currNode = head;
                while (currNode.Next != null)
                {
                    currNode = currNode.Next;
                }
                currNode.Next = node;
            }
            Count++;
        }


        public T GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            return head.Element;
        }

        public T GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            var node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Element;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = head;
            head = oldHead.Next;

            Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Node current = this.head;
            Node last = null;
            // Works only for 1 element in the list
            if (current.Next == null)
            {
                last = this.head;
                this.head = null;
            }
            else
            {
                while (current != null)
                {
                    // Works if there are more than 1 elements in the list
                    if (current.Next.Next == null)
                    {
                        last = current.Next;
                        current.Next = null;
                        break;
                    }

                    current = current.Next;
                }
            }

            this.Count--;
            return last.Element;

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