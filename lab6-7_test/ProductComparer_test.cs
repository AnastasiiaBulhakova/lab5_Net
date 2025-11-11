using lab5;

namespace lab6_7_test
{
    [TestClass]
    public class ProductComparer_test
    {
        [TestMethod]
        public void Compare_WhenQuantitiesAreDifferent_ReturnsCorrectOrder()
        {
            var p1 = new Product("Яблука", 25, "Перший", 10);
            var p2 = new Product("Груші", 30, "Перший", 20);
            var comparer = new ProductComparer();

            Assert.IsTrue(comparer.Compare(p1, p2) < 0);
            Assert.IsTrue(comparer.Compare(p2, p1) > 0);
        }

        // Порівняння однакових кількостей
        [TestMethod]
        public void Compare_WhenQuantitiesAreEqual_ReturnsZero()
        {
            var p1 = new Product("Яблука", 25, "Перший", 10);
            var p2 = new Product("Груші", 30, "Другий", 10);
            var comparer = new ProductComparer();

            Assert.AreEqual(0, comparer.Compare(p1, p2));
        }

        // Перевірка, якщо перший продукт null
        [TestMethod]
        public void Compare_WhenFirstProductIsNull_ReturnsZero()
        {
            Product p1 = null;
            var p2 = new Product("Груші", 30, "Перший", 15);
            var comparer = new ProductComparer();

            Assert.AreEqual(0, comparer.Compare(p1, p2));
        }

        // Перевірка, якщо другий продукт null
        [TestMethod]
        public void Compare_WhenSecondProductIsNull_ReturnsZero()
        {
            var p1 = new Product("Яблука", 25, "Перший", 10);
            Product p2 = null;
            var comparer = new ProductComparer();

            Assert.AreEqual(0, comparer.Compare(p1, p2));
        }

        // Перевірка, якщо обидва продукти null
        [TestMethod]
        public void Compare_WhenBothProductsAreNull_ReturnsZero()
        {
            Product p1 = null;
            Product p2 = null;
            var comparer = new ProductComparer();

            Assert.AreEqual(0, comparer.Compare(p1, p2), "Порівняння двох null-об’єктів має повертати 0.");
        }
    }
}