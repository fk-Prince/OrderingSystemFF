using System.Collections.Generic;
using OrderingSystem.Model;
using OrderingSystem.Repository.Ingredients;

namespace OrderingSystem.Services
{
    public class IngredientServices
    {

        private readonly IIngredientRepository ingredientRepository;

        public IngredientServices(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public List<IngredientModel> getIngredients()
        {
            return ingredientRepository.getIngredients();
        }

        public List<IngredientModel> getIngredientsOfMenu(MenuModel variantDetail)
        {
            return ingredientRepository.getIngredientsOfMenu(variantDetail);
        }

        public bool saveIngredientByMenu(int menuId, List<IngredientModel> ingredientSelected, string v)
        {
            return ingredientRepository.saveIngredientByMenu(menuId, ingredientSelected, v);
        }



    }
}
