using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    public class Stack
    {
        Node head;
        public Stack()
        {
            head = null;
        }
        public Stack(string str)
        {
            Node newnode = new Node(str);
            head = newnode;
        }
        public bool isEmpty()
        {
            return head == null;
        }
        public string getValue()
        {
            return head.str;
        }
        public void push(string value)
        {
            Node newnode = new Node(value);
            if (isEmpty())
                head = newnode;
            else
            {
                newnode.next = head;
                head = newnode;
            }
        }
        public void pop(out string value)
        {
            value = "-1";
            if (isEmpty())
                return;
            value = head.str;
            head = head.next;
        }
    }

}
