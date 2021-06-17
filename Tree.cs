using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBinarySearchTree
{
    class Tree
    {
        public Node root;

        public Node Insert(Node n, string name)
        {
            if (n == null)
            {
                return new Node(name);
            }
            else if (name.ToLower().CompareTo(n.dataName.ToLower()) < 0)
            {
                n.left = Insert(n.left, name);
                n.height = UpdateHeight(n);
                n = BalanceNodes(n, name);
            }
            else if (name.ToLower().CompareTo(n.dataName.ToLower()) > 0)
            {
                n.right = Insert(n.right, name);
                n.height = UpdateHeight(n);
                n = BalanceNodes(n, name);
            }
            else
            {
              return n;
            }
            return n;
        }
        public void Insert(string name)
        {
            root = Insert(root, name);
        }

        public int GetHeight(Node n)
        {
            if (n == null) 
            {
                return 0;
            }          
                return n.height;         
        }
        public int Max(int left, int right)
        {
            return (left > right) ? left : right;
        }
        public Node Minimum(Node n)
        {
            while (n.left != null)
            {
                n = n.left;
            }

            return n;
        }
        public int UpdateHeight(Node n)
        {
            
            return Max(GetHeight(n.left), GetHeight(n.right)) + 1;
        }
        public int GetBalance(Node n)
        {
            if (n == null)  
            { 
                return 0;
            }
            return GetHeight(n.left) - GetHeight(n.right);
        }
        public Node BalanceNodes(Node n, string name)
        {
            int balance = GetBalance(n);

            if (balance > 1)
            {
                if(GetBalance(n.left) >=0)
                {
                    n = RightRotate(n);
                }
                else
                {
                    n.left = LeftRotate(n.left);
                    n = RightRotate(n);
                }
            }
            else if (balance < -1)
            {
                if(GetBalance(n.right) <= 0)
                {
                    n = LeftRotate(n);
                }
                else
                {
                    n.right = RightRotate(n.right);
                    n = LeftRotate(n);
                }
            }
            return n;
        }
        public Node LeftRotate(Node a)
        {
            Node b = a.right;
            Node t = b.left;

            b.left = a;
            a.right = t;

            a.height = UpdateHeight(a);
            b.height = UpdateHeight(b);
            return b;
        }

        public Node RightRotate(Node b)
        {
            Node a = b.left;
            Node t = a.right;

            a.right = b;
            b.left = t;

            b.height = UpdateHeight(b);
            a.height = UpdateHeight(a);
            return a;
        }
        public Node Search(Node n, string name)
        {
            while(n != null)
            {
                if (name.ToLower().CompareTo(n.dataName.ToLower()) < 0)
                {
                    n = n.left;
                }
                else if (name.ToLower().CompareTo(n.dataName.ToLower()) > 0)
                {
                    n = n.right;
                }
                else
                {
                    return n;
                }
            }
            return null;
        }
        public Node Search(string name)
        {
            return Search(root, name);
        }
        public void Delete(string name)
        {
            root = Delete(root, name);
        }
        public Node Delete(Node n, string name)
        {
            if (n == null)
            {
                return n;
            }

            if (name.CompareTo(n.dataName) < 0)
            {
                n.left = Delete(n.left, name);
                n.height = UpdateHeight(n);
                n = BalanceNodes(n, name);
            }
            else if (name.CompareTo(n.dataName) > 0)
            {
                n.right = Delete(n.right, name);
                n.height = UpdateHeight(n);
                n = BalanceNodes(n, name);
            }
            else
            {
                Node temp;

                if (n.left == null && n.right == null)
                {
                    n = null;
                }
                else if (n.left == null)
                {
                    temp = n.right;
                    n = temp;
                }
                else if (n.right == null)
                {
                    temp = n.left;
                    n = temp;
                }
                else
                {
                    temp = Minimum(n.right);
                    n.dataName = temp.dataName;
                    n.right = Delete(n.right, name);
                }
            }

            return n;
        }
    }
}
