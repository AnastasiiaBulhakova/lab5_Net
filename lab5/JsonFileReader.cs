using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab5
{
    public class JsonFileReader : IFileLoader
    {
        public async Task<List<T>?> LoadAsync<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return null; // якщо файл не існує

            var json = await File.ReadAllTextAsync(filePath);

            // Якщо файл порожній або тільки пробіли — повертаємо порожній список
            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
            }
            catch (JsonException)
            {
                // Некоректний JSON — повертаємо порожній список
                return new List<T>();
            }
        }
    }
}
