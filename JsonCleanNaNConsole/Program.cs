using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string json = GetData("https://coderbyte.com/api/challenges/json/json-cleaning").Result;
        string response = FilterJsonResponse(json);
        Console.WriteLine(response);
    }
    static async Task<string> GetData(string url)
    {
        HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    private static string FilterJsonResponse(string jsonString)
    {
        string patternPrincipal = "(\\\"\\\"|\\\"[-]\\\"|\"N\\\\\\/A\")";
        string patternKey = "(\"[a-zA-Z]+\":#EmptyCode#,|,\"[a-zA-Z]+\":#EmptyCode#)";
        string patterValue = "(#EmptyCode#,|,#EmptyCode#)";
        string result = Regex.Replace(jsonString, patternPrincipal, "#EmptyCode#");
        result = Regex.Replace(result, patternKey, string.Empty);
        result = Regex.Replace(result, patterValue, string.Empty);
        return result;
    }
}