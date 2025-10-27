using System;
using System.Collections.Generic;
using System.Data;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Ingredients
{
    public interface IIngredientRepository
    {
        List<IngredientModel> getIngredientsOfMenu(MenuModel menu);
        List<IngredientModel> getIngredients();
        List<IngredientStockModel> getIngredientsStock();
        DataView getIngredientsView();

        bool isIngredientNameExists(string name);
        bool saveIngredientByMenu(int menudetail_id, List<IngredientModel> menu, string type);
        bool deductIngredient(int id, int quantity, string reason);
        bool addIngredient(string name, int quantity, string unit, DateTime expiry);
        bool restockIngredient(int id, int quantity, DateTime value, string reason);
        List<string> getInventoryReasons(string type);
    }
}
