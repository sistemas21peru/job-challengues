internal class Program
{
    //https://www.geeksforgeeks.org/symmetric-tree-tree-which-is-mirror-image-of-itself/
    //https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
    private static void Main(string[] args)
    {
        Tree tree = new Tree();
        tree.Root = new Node(10);
        
        tree.Root.Left = new Node(20);
        tree.Root.Right = new Node(20);
        tree.Root.Left.Left = new Node(40);
        tree.Root.Left.Right = new Node(60);
        tree.Root.Right.Left = new Node(60);
        tree.Root.Right.Right = new Node(40);
        bool output = tree.IsSymmetric();
        Console.WriteLine($"IsSymmetric {output}");
    }
}

internal class Tree
{
    public Node? Root { get; set; }
    private void Built(Node? node)
    {
        if (node == null)
            return;
        Built(node.Left);
        Console.Write($"{node.Key} ");
        Built(node.Right);
    }
    public void Built()
    {
        Built(Root);
    }
    public bool IsSymmetric()
    {
        return IsSymmetric(Root, Root);
    }
    private bool IsSymmetric(Node? node1, Node? node2)
    {
        if (node1 == null && node2 == null)
            return true;
        else if (node1 != null && node2 != null && node1.Key == node2.Key)
            return IsSymmetric(node1.Left, node2.Right) && IsSymmetric(node1.Right, node2.Left);
        else
            return false;
    }
}
internal class Node
{
    public int Key { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public Node(int key)
    {
        Key = key;
    }
}