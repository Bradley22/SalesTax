using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    class Items
    {
        public List<Item> Item { get; set; }
      
    }
    class Item
    {
        public Guid UUID { get; set; }
        public String Name { get; set; }
        public int Qty { get; set; }
        public String Type { get; set; }
        public decimal Price { get; set; }
        public bool Imported { get; set; }
    }
}
