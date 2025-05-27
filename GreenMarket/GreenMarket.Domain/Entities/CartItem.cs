namespace GreenMarket.Domain.Entities
{
    public class CartItem : BaseEntity<int>
    {
        public int Quantity { get; private set; }

        public int CartId { get; private set; }
        public virtual Cart? Cart { get; private set; }

        public int ProductId { get; private set; }
        public virtual Product? Product { get; private set; }

        public int? ProductVariantId { get; private set; }
        public virtual ProductVariant? ProductVariant { get; private set; }
    }
}
