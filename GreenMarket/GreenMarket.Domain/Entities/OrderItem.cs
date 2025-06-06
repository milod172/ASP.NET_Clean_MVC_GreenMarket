﻿namespace GreenMarket.Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int ProductVariantId { get; set; }
        public virtual ProductVariant? ProductVariant { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
