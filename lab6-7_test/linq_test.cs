using lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_7_test
{
    [TestClass]
    public class linq_test
    {
        private ProductCatalog _catalog;

        [TestInitialize]
        public void Setup()
        {
            _catalog = new ProductCatalog(null, null, "dummyPath");

            _catalog.AddProduct(new Product("Apple", 10, "A", 5));
            _catalog.AddProduct(new Product("Banana", 5, "B", 10));
            _catalog.AddProduct(new Product("apple", 12, "A", 3));
            _catalog.AddProduct(new Product("Orange", 8, "C", 7));
        }

        [TestMethod]
        public void FilterByName_ShouldReturnAllMatchingProducts_IgnoringCase()
        {
            // Act
            _catalog.FilterByName("apple");

            // Assert
            Assert.AreEqual(2, _catalog.Products.Count);
            Assert.IsTrue(_catalog.Products.All(p => p.Type.Equals("apple", System.StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod]
        public void GroupByGrade_ShouldSortProductsByGrade()
        {
            // Act
            _catalog.GroupByGrade();

            // Assert
            var grades = _catalog.Products.Select(p => p.Grade).ToList();
            var sortedGrades = grades.OrderBy(g => g).ToList();
            CollectionAssert.AreEqual(sortedGrades, grades);
        }

        [TestMethod]
        public void TotalQuantity_ShouldReturnSumOfAllQuantities()
        {
            // Act
            int total = _catalog.TotalQuantity();

            // Assert
            Assert.AreEqual(5 + 10 + 3 + 7, total);
        }

        [TestMethod]
        public void TotalPrice_ShouldReturnSumOfPriceTimesQuantity()
        {
            // Act
            double totalPrice = _catalog.TotalPrice();

            // Assert
            double expected = (10 * 5) + (5 * 10) + (12 * 3) + (8 * 7);
            Assert.AreEqual(expected, totalPrice);
        }

        [TestMethod]
        public void AveragePrice_ShouldReturnAveragePriceForGivenProductName()
        {
            // Act
            double avgApple = _catalog.AveragePrice("apple");
            double expectedApple = (10 + 12) / 2.0;

            double avgBanana = _catalog.AveragePrice("Banana");
            double avgPear = _catalog.AveragePrice("Pear");

            // Assert
            Assert.AreEqual(expectedApple, avgApple);
            Assert.AreEqual(5, avgBanana);
            Assert.AreEqual(0, avgPear);
        }
    }
}
