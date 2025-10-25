using System.Drawing;

namespace OrderingSystem.Model
{
    public class CategoryModel
    {
        public CategoryModel(int CategoryId, string CategoryName, Image CategoryImage)
        {
            this.CategoryName = CategoryName;
            this.CategoryId = CategoryId;
            this.CategoryImage = CategoryImage;
        }
        public string CategoryName { get; protected set; }
        public int CategoryId { get; protected set; }
        public Image CategoryImage { get; protected set; }
    }
}
