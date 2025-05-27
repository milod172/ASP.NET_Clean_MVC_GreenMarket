namespace GreenMarket.Domain.Entities
{
    public class Cart : BaseEntity<int>
    {
        public string? CustomerId {  get; set; }

        public virtual ApplicationUser? Customer {  get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = [];
       
    }
}
