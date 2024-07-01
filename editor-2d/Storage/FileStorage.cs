using Newtonsoft.Json;

namespace Krista
{
    public class FileStorage : IStorage
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public FileStorage()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.None
            };
        }

        public void SaveData<T>(string path, T data)
        {
            try
            {
                using var writer = new StreamWriter(path, false);
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                var json = JsonConvert.SerializeObject(data, _jsonSerializerSettings);
                writer.Write(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public T LoadData<T>(string path)
        {
            using var reader = new StreamReader(path);
            var text = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(text, _jsonSerializerSettings) ??
                   throw new InvalidOperationException();
        }
    }
}