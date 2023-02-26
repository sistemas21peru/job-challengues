internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = { 1, 4, 5, 5, 5, 5, 1, 9, 2, 2, 3 };
        int valueToSearch = 2;
        PrintFirstAndLastIndex(input, valueToSearch);
    }
    private static void PrintFirstAndLastIndex(int[] input, int valueToSearch)
    {
        int left = 0;
        int right = 0;
        int index = 0;
        while (index <= input.Length - 1)
        {
            if (input[index] == valueToSearch)
            {
                if (left == 0)
                    left = index;
                right = index;
            }
            index++;
        }
        if (right == left)
            Console.WriteLine($"{-1} // {-1}");
        else
            Console.WriteLine($"{left} // {right}");
    }
}