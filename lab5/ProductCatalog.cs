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
            var sortedProducts = new List<Product>(_allProducts);
            sortedProducts.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));
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
    }
}
