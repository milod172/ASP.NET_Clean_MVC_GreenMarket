namespace GreenMarket.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string ProductName { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal? UnitPrice { get; private set; }
        public string? Details { get; private set; } = string.Empty; 
        public int TotalQuantity { get; private set; } = 0;
        public string Sku { get; set; } = string.Empty;
        public int TotalSell { get; private set; } = 0;
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = [];
        public virtual ICollection<CartItem> CartItems { get; set; } = [];
        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
        public virtual ICollection<ProductImage> ProductImages { get; set; } = [];
    }
}
