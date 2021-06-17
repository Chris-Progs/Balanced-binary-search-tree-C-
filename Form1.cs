using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Chris
// Balanced Binary Tree Program - AT2.2
namespace BalancedBinarySearchTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Tree btree = new Tree();
        /* Insert button method to insert a name into the tree. 
           The method first checks for input to the text box and if there isn't, a message is displayed.
           Then it calls the Search method in the tree class before adding it to the tree, if the name is found a message is displayed. 
           Should the name be new the method then calls the recursive Insert method from Tree class and displays the names in the list box 
           using the DisplayTree method which further calls the recursive WalkTree method.
           Finally the ClearTextBox method is called, ready for new user input. */
        private void insertBtn_Click(object sender, EventArgs e)
        {
            string name = textBox.Text;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                Node n = btree.Search(name);
                
                if (n != null)
                {
                    MessageBox.Show("Name already exists");
                    ClearTextBox();
                }
                else
                {
                    btree.Insert(name);
                    DisplayTree();
                    ClearTextBox();
                }                
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
        }
        // Custom clear text box method
        public void ClearTextBox()
        {
            textBox.Clear();
        }
        /* Display tree method first clears the listbox and checks if the root is not equal to null.
           The method then calls the recursive WalkTree method. */
        public void DisplayTree()
        {
            listBox1.Items.Clear();
            if (btree.root != null)
            {
                WalkTree(btree.root);
            }
        }
        /* WalkTree method recursively traverses the tree and adds each name to the list box.
           The method also identifies and lists the current root of the tree and which are left or right. */
        public void WalkTree(Node n)
        {
            if (n.left != null)
            {
                WalkTree(n.left);
            }
            if (n == btree.root){
                listBox1.Items.Add(n.dataName + " (Root)");
            }
            else if (n.dataName.CompareTo(btree.root.dataName) < 0)
            {
                listBox1.Items.Add(n.dataName + " (Left)");
            }
            else if (n.dataName.CompareTo(btree.root.dataName) > 0)
            {
                listBox1.Items.Add(n.dataName + " (Right)");
            }
                if (n.right != null)
            {
                WalkTree(n.right);
            }
        }
        /* Search button method to find a specific name within the tree.
           The method first checks for input to the text box and if there is a matching name in the list box
           it will be displayed in a message box saying or not found based on the success of the search.
           The method then calls the ClearTextBox method to remove the user input ready for a new search. */
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string name = textBox.Text;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                Node n = btree.Search(name);
                
                if(n == null)
                {
                    MessageBox.Show(textBox.Text + " Not found");
                    ClearTextBox();
                }
                else
                {
                    MessageBox.Show(textBox.Text + " Found");
                    ClearTextBox();
                }
            }

        }
        /* Delete button method to delete a specific name from the tree.
           The method first checks for user input to the text box and displays a message if the user did not.
           Then the Search method is called from the tree class and if the name is not found, a message will be displayed.
           If a name is found then it will be deleted from the tree, afterwhich the DisplayTree method is called to re-populate the list box.
           Finally the ClearTextBox method is called, ready for the next user input. */
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string name = textBox.Text;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                Node n = btree.Search(name);

                if (n == null)
                {
                    MessageBox.Show(textBox.Text + " Not found");
                    ClearTextBox();
                }
                else
                {
                    btree.Delete(name);
                    DisplayTree();
                    ClearTextBox();
                }
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
         }
        }
    }

