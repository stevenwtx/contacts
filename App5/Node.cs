using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    public class Node
    {
        public string str;
        public Node next;
        public Node(string str)
        {
            this.str = str;
            this.next = null;
        }
    }

}
