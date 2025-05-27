using GreenMarket.Domain.Enums;

namespace GreenMarket.Domain.Entities
{
    public class Order :BaseEntity<int>
    {
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string? TransactionId { get; set; }       //ID from payment gateway
        public DateTime? PaymentDate {  get; set; }
        public Address ShippingAddress { get; set; } = new();
        public string? CustomerId { get; set; }
        public virtual ApplicationUser? Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}
