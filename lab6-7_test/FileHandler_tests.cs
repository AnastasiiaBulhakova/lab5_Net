using lab5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace lab6_7_test
{
    [TestClass]
    public class FileHandler_tests
    {
        private string testFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            testFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".json");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
        }

        [TestMethod]
        public async Task LoadAsync_ShouldReadDataFromFile()
        {
            string jsonContent = "[{\"Type\":\"Масло\",\"Price\":42.3,\"Grade\":\"Перший\",\"Quantity\":3}]";
            await File.WriteAllTextAsync(testFilePath, jsonContent);

            var fileReader = new JsonFileReader();
            var loadedProducts = await fileReader.LoadAsync<Product>(testFilePath);

            Assert.IsNotNull(loadedProducts);
            Assert.AreEqual(1, loadedProducts.Count);
            Assert.AreEqual("Масло", loadedProducts[0].Type);
            Assert.AreEqual(3, loadedProducts[0].Quantity);
            Assert.AreEqual(42.3, loadedProducts[0].Price);
        }

        [TestMethod]
        public async Task LoadAsync_WhenFileDoesNotExist_ReturnsNull()
        {
            var fileReader = new JsonFileReader();
            var loadedProducts = await fileReader.LoadAsync<Product>(testFilePath);

            Assert.IsNull(loadedProducts, "Повинен повертати null, якщо файл не існує.");
        }

        [TestMethod]
        public async Task LoadAsync_WhenFileIsEmpty_ReturnsEmptyList()
        {
            await File.WriteAllTextAsync(testFilePath, ""); // порожній файл
            var fileReader = new JsonFileReader();

            var result = await fileReader.LoadAsync<Product>(testFilePath);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count, "Очікується порожній список при пустому файлі.");
        }

        [TestMethod]
        public async Task LoadAsync_WhenFileContainsWhitespace_ReturnsEmptyList()
        {
            await File.WriteAllTextAsync(testFilePath, "   "); // файл з пробілами
            var fileReader = new JsonFileReader();

            var result = await fileReader.LoadAsync<Product>(testFilePath);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count, "Очікується порожній список при файлі з пробілами.");
        }
        [TestMethod]
        public async Task SaveAsync_ShouldWriteDataToFile_And_CanReadBack()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("Молоко", 25.5, "Перший", 10),
                new Product("Хліб", 15.0, "Другий", 5)
            };

            var fileSaver = new JsonFileWriter(); 

            // Act
            await fileSaver.SaveAsync(testFilePath, products);

            // Assert файл створено та не порожній
            Assert.IsTrue(File.Exists(testFilePath), "Файл не було створено.");
            string fileContent = await File.ReadAllTextAsync(testFilePath);
            Assert.IsFalse(string.IsNullOrWhiteSpace(fileContent), "Файл порожній.");

            // Додаткова перевірка: десеріалізація через JsonFileReader
            var fileReader = new JsonFileReader();
            var loadedProducts = await fileReader.LoadAsync<Product>(testFilePath);

            Assert.IsNotNull(loadedProducts, "Десеріалізація не вдалася.");
            Assert.AreEqual(2, loadedProducts.Count, "Кількість десеріалізованих об'єктів не збігається.");
            Assert.AreEqual("Молоко", loadedProducts[0].Type);
            Assert.AreEqual(10, loadedProducts[0].Quantity);
            Assert.AreEqual("Хліб", loadedProducts[1].Type);
            Assert.AreEqual(5, loadedProducts[1].Quantity);
        }
    }
}
