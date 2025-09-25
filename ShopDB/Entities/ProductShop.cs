using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.Entities
{
    internal class ProductShop
    {
        public ICollection<Shop> Shop { get; set; }
        public int ShopID { get; set; }
        public ICollection<Product> Product { get; set; }
        public int ProductID { get; set; }
    }
}
