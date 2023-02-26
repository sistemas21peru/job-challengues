using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        string value1 = "nameless1";
        string value2 = "salesmen1";
        Console.WriteLine($"IsValidAnagram is {IsValidAnagram(value1, value2)}");
    }

    private static bool IsValidAnagram(string value1, string value2)
    {
        bool response = true;
        if (value1.Length == value2.Length)
        {
            var hashTable1 = GetHashtable(value1);
            var hashTable2 = GetHashtable(value2);
            foreach (DictionaryEntry item in hashTable1)
            {
                var keyValue1 = hashTable1[item.Key];
                var keyValue2 = hashTable2[item.Key];
                if (!hashTable2.ContainsKey(item.Key) ||
                (keyValue1 != null && keyValue2 != null && !keyValue1.Equals(keyValue2)))
                {
                    response = false;
                    break;
                }
            }
        }
        else
            response = false;
        return response;
    }
    private static Hashtable GetHashtable(string value1)
    {
        Hashtable response = new Hashtable();
        char[] chars = value1.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            string key = chars[i].ToString();
            if (response.ContainsKey(key))
                response[key] = Convert.ToInt32(response[key]) + 1;
            else
                response.Add(key, 1);
        }
        return response;
    }
}