using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Ingredients
{
    public interface IIngredientRepository
    {
        List<IngredientModel> getIngredientsOfMenu(MenuModel menu);

        List<IngredientModel> getIngredients();

        bool saveIngredientByMenu(int menudetail_id, List<IngredientModel> menu, string type);
    }
}
