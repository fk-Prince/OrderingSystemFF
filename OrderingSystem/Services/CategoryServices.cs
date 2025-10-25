using System.Collections.Generic;
using System.Drawing;
using OrderingSystem.Exceptions;
using OrderingSystem.Model;
using OrderingSystem.Repository.CategoryRepository;

namespace OrderingSystem.Services
{
    public class CategoryServices
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<CategoryModel> getCategories()
        {
            return categoryRepository.getCategories();
        }
        public List<CategoryModel> getCategoriesByMenu()
        {
            return categoryRepository.getCategoriesByMenu();
        }

        public bool createCategory(string name, Image image)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidInput("Category Name is required.");
            }

            CategoryModel c = new CategoryModel(0, name, image);
            if (isCategoryNameExists(c))
            {
                throw new DuplicateException("Category Name already exists.");
            }

            return categoryRepository.createCategory(c);
        }

        public bool updateCateogry(int id, string name, Image image)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidInput("Category Name is required.");
            }

            CategoryModel c = new CategoryModel(id, name, image);
            if (isCategoryNameExists(c))
            {
                throw new DuplicateException("Category Name already exists.");
            }

            return categoryRepository.updateCategory(c);
        }

        public bool isCategoryNameExists(CategoryModel c)
        {
            return categoryRepository.isCategoryNameExists(c);
        }
    }
}
