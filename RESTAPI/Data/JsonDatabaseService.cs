using System.IO;
using System.Xml;
using System.Text.Json;
using System;

namespace RestApi.Data
{
    public class JsonDatabaseService
    {
        private readonly string _databaseFolderPath;

        public JsonDatabaseService(string databaseFolderPath)
        {
            _databaseFolderPath = databaseFolderPath;
        }

        public T LoadData<T>(string fileName)
        {
            var filePath = Path.Combine(_databaseFolderPath, fileName);
            if (!File.Exists(filePath)) return default;

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public void SaveData<T>(string fileName, T data)
        {
            var filePath = Path.Combine(_databaseFolderPath, fileName);
            var jsonData = JsonSerializer.Serialize(data, options: new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }
    }
}