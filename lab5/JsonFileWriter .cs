using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab5
{
    public class JsonFileWriter : IFileSaver
    {
        public async Task SaveAsync<T>(string filePath, List<T> data)
        {
            string? directoryPath = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
