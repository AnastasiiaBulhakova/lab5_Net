using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Product
    {
        private string type;
        private double price;
        private string grade;
        private int quantity;

        public string Type
        {
            get => type;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тип продукції не може бути порожнім", nameof(Type));
                type = value;
            }
        }

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна не може бути від’ємною", nameof(Price));
                price = value;
            }
        }

        public string Grade
        {
            get => grade;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Сорт не може бути порожнім", nameof(Grade));
                grade = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Кількість не може бути від’ємною", nameof(Quantity));
                quantity = value;
            }
        }

        public Product(string type, double price, string grade, int quantity)
        {
            Type = type;
            Price = price;
            Grade = grade;
            Quantity = quantity;
        }

        // Для IComparable — порівняння за видом
        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return string.Compare(this.Type, other.Type, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{Type}, сорт: {Grade}, ціна: {Price} грн, кількість: {Quantity}";
        }
    }
}
