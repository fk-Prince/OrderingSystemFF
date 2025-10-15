using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        List<CategoryModel> getCategories();
    }
}
