using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(ShortestPath(new string[] { "5", "A", "B", "C", "D", "F", "D-F", "C-D", "B-C", "A-B", "A-C" }));
        Console.WriteLine(ShortestPath(new string[] { "7", "A", "B", "C", "D", "E", "F", "G", "A-B", "A-E", "B-C", "C-D", "D-F", "E-D", "F-G" }));
        Console.WriteLine(ShortestPath(new string[] { "4", "X", "Y", "Z", "W", "X-Y", "Y-Z", "X-W" }));
    }

    static string ShortestPath(string[] strArr)
    {
        var getNodes = GetNodes(strArr);
        var nodeManager = InitializeNode(getNodes.Item1, getNodes.Item2);
        var getLastNode = nodeManager.LstNode[nodeManager.LstNode.Count - 1];
        BuiltSize(getLastNode);
        return nodeManager.Result();
    }
    static Tuple<List<string>, List<string>> GetNodes(string[] strArr)
    {
        var nodeA = new List<string>();
        var nodeB = new List<string>();
        for (int i = 1; i < strArr.Length; i++)
        {
            if (i <= int.Parse(strArr[0]))
                nodeA.Add(strArr[i]);
            else
                nodeB.Add(strArr[i]);
        }
        return Tuple.Create(nodeA, nodeB);
    }
    static NodeManager InitializeNode(List<string> nodeA, List<string> nodeB)
    {
        var nodeManager = new NodeManager(nodeA);
        foreach (var node in nodeManager.LstNode)
        {
            foreach (var connection in nodeB)
            {
                if (connection.Contains(node.Name))
                {
                    string[] lstNode = connection.Split('-');
                    Node? value = lstNode[0].Equals(node.Name, StringComparison.OrdinalIgnoreCase)
                        ? nodeManager.Search(lstNode[1]) : nodeManager.Search(lstNode[0]);
                    if (value != null)
                        node.Add(value);
                }
            }
        }
        return nodeManager;
    }
    static void BuiltSize(Node node)
    {
        if (node.IsEnd)
            node.Size = 1;
        foreach (var item in node.NextNode)
        {
            int weight = node.Size + 1;
            if (item.Size == 0 || weight < item.Size)
            {
                item.Size = node.Size + 1;
                if (!item.IsStart)
                    BuiltSize(item);
            }
        }
    }
}

internal class NodeManager
{
    public int NumberOfNode { get; set; }
    public List<Node> LstNode { get; set; }
    public NodeManager(List<string> lstNode)
    {
        NumberOfNode = lstNode.Count;
        LstNode = new List<Node>();
        for (int i = 0; i < lstNode.Count; i++)
        {
            LstNode.Add(new Node(lstNode[i], i == 0, i == lstNode.Count - 1));
        }
    }
    public Node? Search(string name)
    {
        return LstNode.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    public string Result()
    {
        var getNode = LstNode.First();
        if (getNode.Size == 0)
            return "-1";
        var result = new StringBuilder();
        result.Append(getNode.Name).Append("-");
        while ((getNode = getNode.Get()) != null)
        {
            result.Append(getNode.Name);
            if (!getNode.IsEnd)
                result.Append("-");
        }
        return result.ToString();
    }
}
internal class Node
{
    public string Name { get; set; }
    public bool IsStart { get; set; }
    public bool IsEnd { get; set; }
    public int Size { get; set; }
    public List<Node> NextNode { get; set; }
    public Node(string name, bool isStart, bool isEnd)
    {
        Name = name;
        IsStart = isStart;
        IsEnd = isEnd;
        Size = 0;
        NextNode = new List<Node>();
    }
    public void Add(Node node)
    {
        if (node != null)
            NextNode.Add(node);
    }
    public Node? Get()
    {
        Node? node = null;
        if (IsEnd)
            return node;
        node = NextNode.FirstOrDefault(x => x.Size.Equals(Size - 1));
        return node;
    }
}