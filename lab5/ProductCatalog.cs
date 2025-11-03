using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class ProductCatalog
    {
        private readonly IFileSaver _fileSaver;
        private readonly IFileLoader _fileLoader;
        private readonly string _filePath;

        public ObservableCollection<Product> Products { get; }
        private List<Product> _allProducts;

        public ProductCatalog(IFileSaver fileSaver, IFileLoader fileLoader, string filePath)
        {
            _fileSaver = fileSaver;
            _fileLoader = fileLoader;
            _filePath = filePath;
            Products = new ObservableCollection<Product>();
            _allProducts = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            _allProducts.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            _allProducts.Remove(product);
        }

        public void SortByQuantity()
        {
            var sorted = new List<Product>(Products);
            sorted.Sort(); // використовує IComparable (кількість)
            UpdateVisibleCollection(sorted);
        }

        public void FilterByQuantity(int threshold)
        {
            var filtered = _allProducts.Where(p => p.Quantity < threshold).ToList();
            UpdateVisibleCollection(filtered);
        }

        public void ResetFilter()
        {
            UpdateVisibleCollection(_allProducts);
        }

        private void UpdateVisibleCollection(List<Product> newList)
        {
            Products.Clear();
            foreach (var p in newList)
                Products.Add(p);
        }

        public async Task SaveAsync()
        {
            await _fileSaver.SaveAsync(_filePath, _allProducts);
        }

        public async Task LoadAsync()
        {
            var loaded = await _fileLoader.LoadAsync<Product>(_filePath);
            if (loaded != null)
            {
                _allProducts = loaded;
                UpdateVisibleCollection(_allProducts);
            }
        }
    }
}
