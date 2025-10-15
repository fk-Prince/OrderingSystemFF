namespace OrderingSystem.Model
{
    public class CategoryModel
    {
        public CategoryModel(int categoryId, string categoryName)
        {
            CategoryName = categoryName;
            CategoryId = categoryId;
        }

        public string CategoryName { get; protected set; }
        public int CategoryId { get; protected set; }
    }
}
