namespace GreenMarket.Domain.Entities
{
    public class ProductImage : BaseEntity<int>
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public int SortOrder { get; set; } = 0;
        public bool IsPrimary { get; set; } = false;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
