using System;
using System.IO;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        private ProductCatalog _catalog;
        private string _filePath;

        public Form1()
        {
            InitializeComponent();

            // Визначаємо шлях до файлу
            _filePath = _filePath = @"D:\институт\3 курс\.Net\lab5\products.json";

            // Створюємо екземпляр каталогу з реалізацією збереження/завантаження
            _catalog = new ProductCatalog(new JsonFileWriter(), new JsonFileReader(), _filePath);

            // Підв’язуємо колекцію до DataGridView
            dataGridView1.DataSource = _catalog.Products;
        }

        // Додавання
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                string typeValue = type.Text.Trim();
                string gradeValue = grade.Text.Trim();

                if (string.IsNullOrWhiteSpace(typeValue) || string.IsNullOrWhiteSpace(gradeValue))
                {
                    MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double priceValue = double.Parse(textBox1.Text);
                int quantityValue = int.Parse(quantity.Text);

                var product = new Product(typeValue, priceValue, gradeValue, quantityValue);

                _catalog.AddProduct(product);

                type.Clear();
                grade.Clear();
                quantity.Clear();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Видалення
        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is Product product)
            {
                _catalog.DeleteProduct(product);
            }
            else
            {
                MessageBox.Show("Оберіть рядок для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Фільтрація
        private void filter_Click(object sender, EventArgs e)
        {
            int maxQuantity = (int)fiter.Value;
            _catalog.FilterByQuantity(maxQuantity);
        }

        // Сортування
        private void sort_Click(object sender, EventArgs e)
        {
            _catalog.SortByQuantity();
        }

        // Скидання
        private void resert_Click(object sender, EventArgs e)
        {
            _catalog.ResetFilter();
        }

        // Завантаження
        private async void load_Click(object sender, EventArgs e)
        {
            try
            {
                await _catalog.LoadAsync();
                MessageBox.Show("Дані успішно завантажено!", "Завантаження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Збереження
        private async void save_Click(object sender, EventArgs e)
        {
            try
            {
                await _catalog.SaveAsync();
                MessageBox.Show("Дані успішно збережено!", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //фільтрація за назвою
        private void Filternew_Click(object sender, EventArgs e)
        {
            string productName = filtertype.Text;
            if (!string.IsNullOrWhiteSpace(productName))
            {
                _catalog.FilterByName(productName);
            }
        }

        // середня ціна продукту
        private void aprice_Click(object sender, EventArgs e)
        {
            string productName = filtertype.Text;
            if (!string.IsNullOrWhiteSpace(productName))
            {
                avprice.Text = _catalog.AveragePrice(productName).ToString();

            }
        }

        private void groupby_Click(object sender, EventArgs e)
        {
            _catalog.GroupByGrade();
        }

        private void tquantity_Click(object sender, EventArgs e)
        {
            allquantity.Text = _catalog.TotalQuantity().ToString();
        }

        private void tprice_Click(object sender, EventArgs e)
        {
            allprice.Text = _catalog.TotalPrice().ToString();
        }
    }
}
