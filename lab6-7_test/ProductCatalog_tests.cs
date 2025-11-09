using lab5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace lab6_7_test
{
    [TestClass]
    public class ProductCatalog_tests
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
        public void AddProduct_ShouldAddToBothCollections()
        {
            var catalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), testFilePath);
            var product = new Product("Молоко", 25.5, "Перший", 10);

            catalog.AddProduct(product);

            Assert.AreEqual(1, catalog.Products.Count);
            Assert.AreEqual("Молоко", catalog.Products[0].Type);
        }

        [TestMethod]
        public void DeleteProduct_ShouldRemoveFromBothCollections()
        {
            var catalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), testFilePath);
            var product = new Product("Молоко", 25.5, "Перший", 10);
            catalog.AddProduct(product);

            catalog.DeleteProduct(product);

            Assert.AreEqual(0, catalog.Products.Count);
        }

        [TestMethod]
        public void SortByQuantity_ShouldSortProductsAscending()
        {
            var catalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), testFilePath);
            catalog.AddProduct(new Product("Хліб", 15, "Другий", 5));
            catalog.AddProduct(new Product("Молоко", 25.5, "Перший", 10));

            catalog.SortByQuantity();

            Assert.AreEqual(5, catalog.Products[0].Quantity);
            Assert.AreEqual(10, catalog.Products[1].Quantity);
        }

        [TestMethod]
        public void FilterByQuantity_ShouldShowOnlyProductsLessThanGivenValue()
        {
            var catalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), testFilePath);
            catalog.AddProduct(new Product("Хліб", 15, "Другий", 5));
            catalog.AddProduct(new Product("Молоко", 25.5, "Перший", 10));

            catalog.FilterByQuantity(10);

            Assert.AreEqual(1, catalog.Products.Count);
            Assert.AreEqual("Хліб", catalog.Products[0].Type);
        }

        [TestMethod]
        public void ResetFilter_ShouldShowAllProducts()
        {
            var catalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), testFilePath);
            catalog.AddProduct(new Product("Хліб", 15, "Другий", 5));
            catalog.AddProduct(new Product("Молоко", 25.5, "Перший", 10));

            catalog.FilterByQuantity(10);
            catalog.ResetFilter();

            Assert.AreEqual(2, catalog.Products.Count);
        }

        [TestMethod]
        public async Task SaveAsync_And_LoadAsync_ShouldPersistData()
        {
            var catalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), testFilePath);
            catalog.AddProduct(new Product("Молоко", 25.5, "Перший", 10));
            catalog.AddProduct(new Product("Хліб", 15, "Другий", 5));

            await catalog.SaveAsync();

            // Перевірка, що файл існує
            Assert.IsTrue(File.Exists(testFilePath));

            // Створюємо новий каталог для завантаження
            var loadedCatalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), testFilePath);
            await loadedCatalog.LoadAsync();

            Assert.AreEqual(2, loadedCatalog.Products.Count);
            Assert.AreEqual("Молоко", loadedCatalog.Products[0].Type);
            Assert.AreEqual(10, loadedCatalog.Products[0].Quantity);
            Assert.AreEqual("Хліб", loadedCatalog.Products[1].Type);
            Assert.AreEqual(5, loadedCatalog.Products[1].Quantity);
        }
    }
}
