using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMarket.Domain.Entities
{
    public class ProductVariant : BaseEntity<int>
    {
        public string VariantName { get; set; } = string.Empty;
        public string VariantSku { get; set; } = string.Empty;

        private readonly int minStock = 0;

        private int stockQuantity;
        
        public int StockQuantity
        {
            get { return stockQuantity; }
            set
            {
                stockQuantity = value < minStock ? minStock : value;
            }
        }

        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = [];
        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}

       
