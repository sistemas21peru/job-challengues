internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = { 1, 2, 3, 4, 5, 6 };
        int target = 6;
        var result = GetResult(input, target);
        Console.WriteLine($"{result[0]} - {result[1]}");
    }

    static int[] GetResult(int[] input, int target)
    {
        int[] result = new int[2];
        int indexInit = 0;
        while (indexInit != input.Length - 1)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (indexInit != i && input[i] < target && (input[indexInit] + input[i] == target))
                {
                    result[0] = indexInit;
                    result[1] = i;
                    break;
                }
            }
            indexInit++;
        }
        return result;
    }
}