// Homework 5: Trees  (starter code)
// 1. Finish every method marked TODO. Use loops, not recursion.
// 2. Write your answers for Questions 1 to 5 in the comment box at the bottom of this file.
// Do not change the tests in Main. Run with: dotnet run
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // ======================= TESTS (do not change) =======================
        var empty = new BinarySearchTree();
        var one = new BinarySearchTree();
        one.Insert(7);
        var t1 = new BinarySearchTree();
        foreach (int v in new[] { 50, 30, 70, 20, 40, 80, 35, 45 }) t1.Insert(v);
        var line = new BinarySearchTree();
        foreach (int v in new[] { 10, 20, 30, 40, 50 }) line.Insert(v);

        Console.WriteLine("== Min ==");
        Console.WriteLine(t1.Min());
        Console.WriteLine(line.Min());
        Console.WriteLine(one.Min());
        Console.WriteLine();

        Console.WriteLine("== Max ==");
        Console.WriteLine(t1.Max());
        Console.WriteLine(line.Max());
        Console.WriteLine(one.Max());
        Console.WriteLine();

        Console.WriteLine("== Depth ==");
        Console.WriteLine(t1.Depth(50));
        Console.WriteLine(t1.Depth(70));
        Console.WriteLine(t1.Depth(35));
        Console.WriteLine(t1.Depth(99));
        Console.WriteLine(line.Depth(50));
        Console.WriteLine(empty.Depth(5));
        Console.WriteLine();
    }
}

// ======================= CLASSES =======================
public class Node
{
    public int Value;
    public Node? Left;
    public Node? Right;
    public Node(int value) { Value = value; }
}

public class BinarySearchTree
{
    private Node? root;
    public Node? Root => root;

    public bool Insert(int value)
    {
        Node newNode = new Node(value);
        if (root == null) { root = newNode; return true; }
        Node temp = root;
        while (true)
        {
            if (newNode.Value == temp.Value) return false;
            if (newNode.Value < temp.Value)
            {
                if (temp.Left == null) { temp.Left = newNode; return true; }
                temp = temp.Left;
            }
            else
            {
                if (temp.Right == null) { temp.Right = newNode; return true; }
                temp = temp.Right;
            }
        }
    }

    public bool Contains(int value)
    {
        Node? temp = root;
        while (temp != null)
        {
            if (value < temp.Value) temp = temp.Left;
            else if (value > temp.Value) temp = temp.Right;
            else return true;
        }
        return false;
    }

    // Smallest value in a BST is the leftmost node.
    public int Min()
    {
        Node temp = root!;
        while (temp.Left != null)
        {
            temp = temp.Left;
        }
        return temp.Value;
    }

    // Biggest value in a BST is the rightmost node.
    public int Max()
    {
        Node temp = root!;
        while (temp.Right != null)
        {
            temp = temp.Right;
        }
        return temp.Value;
    }

    // Depth of the node that holds "value".
    // The root has depth 0. If the value is not in the tree, return -1.
    public int Depth(int value)
    {
        Node? temp = root;
        int depth = 0;
        while (temp != null)
        {
            if (value < temp.Value)
            {
                temp = temp.Left;
                depth++;
            }
            else if (value > temp.Value)
            {
                temp = temp.Right;
                depth++;
            }
            else
            {
                return depth;
            }
        }
        return -1;
    }
}

/* ======================= WRITTEN ANSWERS (Questions 1 to 5) =======================
   Type your answers here. Draw trees with spaces and slashes, like the trees on the
   assignment page.

   Question 1
   a) root: 50
   b) leaves: 20, 35, 45, 80
   c) internal nodes: 50, 30, 40, 70
   d) parent of 35: 40         sibling of 20: 40
   e) depth of 35: 3           height of node 30: 2
   f) height of tree: 3        size: 8
   g) degree of 70: 1
   h) valid BST? Yes.
      At node 30 the left subtree is only 20, and 20 < 30.
      Every value in the right subtree (35, 40, 45) is greater than 30.
      The same left-smaller / right-greater rule holds at every other node,
      so this is a correct BST.

   Question 2   (Yes / No)
                 Tree A    Tree B    Tree C
   Full?         Yes       Yes       Yes
   Perfect?      No        Yes       No
   Complete?     Yes       Yes       No
   Reasons for each No:
   - Tree A is not perfect because its leaves are not all on the same level:
     12 is a leaf, while 2 and 6 sit one level lower.
   - Tree C is not perfect because leaf 4 is one level above leaves 10 and 14.
   - Tree C is not complete because the bottom level is not packed to the left:
     4 has no children, but 12 (farther right) does.

   Question 3
   a) tree:

            41
           /  \
         20    65
         / \   / \
       11  29 50  91
             \   /  \
             32 72   99

   b) height: 3                number of leaves: 5 (11, 32, 50, 72, 99)
   c) Contains(32) visits: 41, 20, 29, 32     returns: true
      Contains(60) visits: 41, 65, 50         returns: false

   Question 4
   a) tree:

      10
        \
         20
           \
            30
              \
               40
                 \
                  50

      height: 4
   b) nodes visited by Contains(50): 5 (10, 20, 30, 40, 50)
      Big O: O(n)
      acts like: a linked list

   Question 5
   a) tree:

                  90
                /    \
             70        85
            /  \      /  \
          40    65  80    30
         /  \
       10    35

   b) children of 70 (show math):
      70 is at index 1.
      left  = 2 * 1 + 1 = 3, and array[3] = 40
      right = 2 * 1 + 2 = 4, and array[4] = 65
      So the children of 70 are 40 and 65.

   c) parent of 35 (show math):
      35 is at index 8.
      parent = (8 - 1) / 2 = 3, and array[3] = 40
      So the parent of 35 is 40.

   d) why 65 is a leaf (show math):
      65 is at index 4. The array's last index is 8.
      left  = 2 * 4 + 1 = 9, which is past the end, so there is no left child.
      right = 2 * 4 + 2 = 10, which is past the end, so there is no right child.
      A node with no children is a leaf.
*/
