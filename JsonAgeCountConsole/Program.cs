using System.Net;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string json = GetData("https://coderbyte.com/api/challenges/json/age-counting").Result;
        int response = GetCount(json);
        Console.WriteLine(response);
    }
    static async Task<string> GetData(string url)
    {
        HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    static int GetCount(string json)
    {
        int count = 0;
        foreach (Match item in Regex.Matches(json, "(?<=age=)[0-9]+"))
        {
            if (item.Success && int.Parse(item.Value) >= 50)
                count++;
        }
        return count;
    }
}