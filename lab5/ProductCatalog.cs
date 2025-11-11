using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace lab5
{
    public class ProductCatalog
    {
        private readonly IFileSaver _fileSaver;
        private readonly IFileLoader _fileLoader;
        private readonly string _filePath;

        // Публічна колекція для відображення в UI або роботи з даними
        public BindingList<Product> Products { get; }

        // Приватна колекція для зберігання всіх даних
        private List<Product> _allProducts;

        public ProductCatalog(IFileSaver fileSaver, IFileLoader fileLoader, string filePath)
        {
            _fileSaver = fileSaver;
            _fileLoader = fileLoader;
            _filePath = filePath;

            Products = new BindingList<Product>();
            _allProducts = new List<Product>();
        }

        // Додавання продукту
        public void AddProduct(Product product)
        {
            Products.Add(product);
            _allProducts.Add(product);
        }

        // Видалення продукту
        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            _allProducts.Remove(product);
        }

        // Сортування за кількістю
        public void SortByQuantity()
        {
            //var sortedProducts = new List<Product>(_allProducts);

            //var comparer = new ProductComparer();

            //sortedProducts.Sort(comparer);

            var sortedProducts = _allProducts
                .OrderBy(p => p.Quantity)
                .ToList();

            UpdateVisibleCollection(sortedProducts);
        }

        // Фільтрація за кількістю менше заданого значення
        public void FilterByQuantity(int maxQuantity)
        {
            var filtered = _allProducts.Where(p => p.Quantity < maxQuantity).ToList();
            UpdateVisibleCollection(filtered);
        }

        // Скидання фільтру — повернення всіх продуктів
        public void ResetFilter()
        {
            UpdateVisibleCollection(_allProducts);
        }

        // Оновлення публічної колекції
        private void UpdateVisibleCollection(List<Product> newList)
        {
            Products.Clear();
            foreach (var p in newList)
                Products.Add(p);
        }

        // Збереження у файл
        public async Task SaveAsync()
        {
            await _fileSaver.SaveAsync(_filePath, _allProducts);
        }

        // Завантаження з файлу
        public async Task LoadAsync()
        {
            var loadedProducts = await _fileLoader.LoadAsync<Product>(_filePath);
            if (loadedProducts != null)
            {
                _allProducts = loadedProducts;
                UpdateVisibleCollection(_allProducts);
            }
        }


        //нові
        // всі продукти з такою назвою
        public void FilterByName(string name)
        {
            var filtered = _allProducts
                .Where(p => string.Equals(p.Type, name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            UpdateVisibleCollection(filtered);
        }


        //Групування продуктів за сортом

        public void GroupByGrade()
        {
            var grouped = _allProducts
                .OrderBy(p => p.Grade)
                .ToList();

            UpdateVisibleCollection(grouped);
        }

        //Загальна кількість всіх продуктів
        public int TotalQuantity()
        {
            return _allProducts.Sum(p => p.Quantity);
        }

        // Загальна вартість всіх продуктів
        public double TotalPrice()
        {
            return _allProducts.Sum(p => p.Price * p.Quantity);
        }

        // Середня ціна продукту
        public double AveragePrice(string name)
        {
            var filtered = _allProducts
                .Where(p => string.Equals(p.Type, name, StringComparison.OrdinalIgnoreCase));
            if (!filtered.Any()) return 0;
            return filtered.Average(p => p.Price);
        }

    }
}
