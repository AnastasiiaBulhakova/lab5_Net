using lab5;

namespace lab6_7_test
{
    [TestClass]
    public class Product_test
    {
        [TestMethod]
        public void Constructor_ShouldInitializeFieldsCorrectly()
        {
            // Arrange + Act
            var product = new Product("Яблука", 25.5, "Перший", 100);

            // Assert
            Assert.AreEqual("Яблука", product.Type);
            Assert.AreEqual(25.5, product.Price);
            Assert.AreEqual("Перший", product.Grade);
            Assert.AreEqual(100, product.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Type_ShouldThrowException_WhenEmpty()
        {
            var product = new Product("", 10, "Вищий", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Price_ShouldThrowException_WhenNegative()
        {
            var product = new Product("Сир", -10, "Другий", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Grade_ShouldThrowException_WhenEmpty()
        {
            var product = new Product("Сир", 50, "", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Quantity_ShouldThrowException_WhenNegative()
        {
            var product = new Product("Сир", 50, "Перший", -2);
        }

        [TestMethod]
        public void CompareTo_ShouldCompareByType()
        {
            var p1 = new Product("Яблука", 25, "Перший", 50);
            var p2 = new Product("Банани", 30, "Перший", 50);

            int result = p1.CompareTo(p2);

            Assert.IsTrue(result > 0); // "Яблука" > "Банани"
        }

        [TestMethod]
        public void ToString_ShouldReturnFormattedString()
        {
            var product = new Product("Апельсини", 40, "Другий", 20);
            string expected = "Апельсини, сорт: Другий, ціна: 40 грн, кількість: 20";
            Assert.AreEqual(expected, product.ToString());
        }
    }
}