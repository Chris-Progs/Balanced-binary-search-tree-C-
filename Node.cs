using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBinarySearchTree
{
    public class Node
    {
        public string dataName;
        public Node left;
        public Node right;
        public int height;


        public Node(string name)
        {
            this.dataName = name;
            height = 1;
        }
    }
}
