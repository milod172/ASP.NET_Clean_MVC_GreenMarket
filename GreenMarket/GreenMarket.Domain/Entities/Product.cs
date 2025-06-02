using System.Globalization;
using System.Text;

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

        public static Product Create(string name, string description, decimal price, int? categoryId, string? details)
        {
            var nameParts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var skuParts = nameParts.Select(part =>
            {
                var noDiacritics = RemoveDiacritics(part);

                
                if (!noDiacritics.Any(char.IsLetter))
                    return noDiacritics;

                return noDiacritics.ToUpperInvariant();
            });

            var generatedSku = string.Join("-", skuParts);

            return new Product
            {
                ProductName = name,
                Description = description,
                UnitPrice = price,
                Sku = generatedSku,
                Details = details,
                CategoryId = categoryId
            };
        }

        private static string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
