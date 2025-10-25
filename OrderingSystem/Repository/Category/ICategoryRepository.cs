using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        List<CategoryModel> getCategoriesByMenu();
        List<CategoryModel> getCategories();
        bool createCategory(CategoryModel c);
        bool updateCategory(CategoryModel c);
        bool isCategoryNameExists(CategoryModel c);
    }
}
