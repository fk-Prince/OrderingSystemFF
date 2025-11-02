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
        bool isIngredientNameExists(string name, int id = 0);
        bool removeExpiredIngredient();
        bool saveIngredientByMenu(int menudetail_id, List<IngredientModel> menu, string type);
        bool deductIngredient(int id, int quantity, string reason);
        bool addIngredient(string name, int quantity, string unit, DateTime expiry, string supplierName, double cost);
        bool restockIngredient(int id, int quantity, DateTime value, string reason, string supplierName, double cost);
        bool updateIngredient(int id, string name, string unit);
        List<string> getInventoryReasons(string type);
        List<string> getSuppliers();
    }
}
