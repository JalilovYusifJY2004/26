
using Newtonsoft.Json;

namespace _2610ok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = "names.json";
            var nameList = JsonConvert.SerializeObject(jsonFilePath);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Zeynal\Desktop\2610ok\files\config1.json"))
            {
                sw.WriteLine(nameList);
            }
            using(StreamReader sr = new StreamReader(@"C:\Users\Zeynal\Desktop\2610ok\files\config1.json"))
            {
                sr.ReadToEnd();
            }
            Add(nameList, "Yusif", jsonFilePath);

            bool searchResult = Search(nameList, name => name.StartsWith("Jo"));
            Console.WriteLine("Name found: " + searchResult);
            Delete(nameList, "Yusif", jsonFilePath);


        }
        private static void Add(List<string> nameList, string name, string filePath)
        {
            nameList.Add(name);
            SerializeToJson(filePath, nameList);
        }

        private static bool Search(List<string> nameList, Predicate<string> condition)
        {
            return nameList.Exists(condition);
        }


        private static void Delete(List<string> nameList, string name, string filePath)
        {
            nameList.Remove(name);
            SerializeToJson(filePath, nameList);
        }

        private static void SerializeToJson(string filePath, List<string> nameList)
        {
            throw new NotImplementedException();
        }

        private static List<string> DeserializeFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<string>>(json);
        }
    }
}
