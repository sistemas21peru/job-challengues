internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = { 4, 2, 9, 7, 5, 6, 7, 1, 3 };
        int k = 4;
        PrintKthLargestElement(input, k);
    }
    private static void PrintKthLargestElement(int[] input, int k)
    {
        int[] array = input.OrderBy(x => x).ToArray();
        for (int i = array.Length; i--> 0;)
        {
            if (i == k + 1)
            {
                Console.WriteLine($"PrintKthLargestElement {array[i]}");
                break;
            }
        }
    }
}