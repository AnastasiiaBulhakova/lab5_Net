using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class ProductComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null || y == null) return 0;
            return x.Quantity.CompareTo(y.Quantity);
        }
    }
}
