using System.Text.Json;

namespace Hometask04._04_GC_KazanovAlexandr
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var data = new JsonHandler("check.js");
            await data.WriteJsonAsync(new {Name = "John", SecondName = "Doe"});
            var res = await data.ReadJsonAsync<dynamic>();
            Console.WriteLine(res);
        }
    }

    public class JsonHandler
    {
        private readonly string _jsonpath;

        public JsonHandler(string jsonpath)
        {
            _jsonpath = jsonpath;
        }

        public async Task WriteJsonAsync<T>(T data)
        {
            using (var serializer = new FileStream(_jsonpath, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(serializer, data);
            }
        }

        public async Task<T> ReadJsonAsync<T>()
        {
            using (var serializer = new FileStream(_jsonpath, FileMode.Open))
            {
                return await JsonSerializer.DeserializeAsync<T>(serializer);
            }
        }
    }
        

}