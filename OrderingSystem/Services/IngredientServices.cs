using System.Collections.Generic;
using System.Data;
using OrderingSystem.Exceptions;
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
        public DataView getIngredientsView()
        {
            return ingredientRepository.getIngredientsView();
        }
        public List<IngredientStockModel> getIngredientStock()
        {
            return ingredientRepository.getIngredientsStock();
        }

        public List<IngredientModel> getIngredientsOfMenu(MenuModel variantDetail)
        {
            return ingredientRepository.getIngredientsOfMenu(variantDetail);
        }

        public bool saveIngredientByMenu(int menuId, List<IngredientModel> ingredientSelected, string v)
        {
            return ingredientRepository.saveIngredientByMenu(menuId, ingredientSelected, v);
        }

        public List<string> getReasons(string type)
        {
            return ingredientRepository.getInventoryReasons(type);
        }


        public bool validateDeductionIngredientStock(int stockId, int quantity, string reason, IngredientModel orig)
        {

            if (quantity <= 0)
            {
                throw new InvalidInput("Invalid Quantity must be greater than zero.");
            }
            if (quantity > orig.IngredientQuantity)
            {
                throw new InvalidInput("Insufficient stock to deduct the requested quantity.");
            }
            return ingredientRepository.deductIngredient(stockId, quantity, reason);
        }
    }
}
