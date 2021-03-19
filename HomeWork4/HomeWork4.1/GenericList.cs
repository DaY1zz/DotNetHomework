using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4._1
{
    class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            head = tail = null;
        }
        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> newNode = new Node<T>(t);
            if (tail == null)
                head = tail = newNode;
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void ForEach(Action<T> action)
        {
            for(Node<T> p = head; p != null; p = p.Next)
            {
                action(p.Data);
            }
        }
    }
}
