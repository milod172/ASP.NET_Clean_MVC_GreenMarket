namespace GreenMarket.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }
        public virtual Category? ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } = [];
        public virtual ICollection<Product> Products { get; set; } = [];

        public static Category Create(string name, string description, int? parentCategoryId)
        {
            return new Category
            {
                CategoryName = name,
                Description = description,
                ParentCategoryId = parentCategoryId
            };
        }
    }
}
