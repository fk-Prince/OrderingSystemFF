using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Newtonsoft.Json;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Ingredients
{
    public class IngredientRepository : IIngredientRepository
    {
        public List<IngredientModel> getIngredients()
        {
            List<IngredientModel> im = new List<IngredientModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT i.ingredient_id, i.ingredient_name, i.unit FROM ingredients i", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IngredientModel i = IngredientModel.Builder()
                                .SetIngredient_id(reader.GetInt32("ingredient_id"))
                                .SetIngredientName(reader.GetString("ingredient_name"))
                                .SetIngredientUnit(reader.GetString("unit"))
                                .Build();
                            im.Add(i);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return im;
        }
        public List<IngredientModel> getIngredientsOfMenu(MenuModel menu)
        {
            List<IngredientModel> im = new List<IngredientModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                string query = "";
                if (menu.MenuDetailId != 0)
                {
                    query = @"
                    SELECT i.ingredient_id, i.ingredient_name,i.unit, COALESCE(SUM(mi.quantity), 0) quantity FROM ingredients i
                    LEFT JOIN menu_ingredient mi ON mi.ingredient_id = i.ingredient_id AND mi.menu_detail_id = @menu_detail_id
                    GROUP BY  i.ingredient_id, i.ingredient_name;";
                }
                else
                {
                    query = @"
                    SELECT i.ingredient_id, i.ingredient_name, i.unit, COALESCE(SUM(CASE WHEN m.menu_id = @menu_id THEN mi.quantity ELSE 0 END), 0) quantity
                    FROM ingredients i
                    LEFT JOIN menu_ingredient mi ON mi.ingredient_id = i.ingredient_id
                    LEFT JOIN menu_detail md ON md.menu_detail_id = mi.menu_detail_id
                    LEFT JOIN menu m ON m.menu_id = md.menu_id
                    GROUP BY i.ingredient_id;
                    ";
                }
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {

                    if (menu.MenuDetailId != 0) cmd.Parameters.AddWithValue("@menu_detail_id", menu.MenuDetailId);
                    else cmd.Parameters.AddWithValue("@menu_id", menu.MenuId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IngredientModel i = IngredientModel.Builder()
                                .SetIngredient_id(reader.GetInt32("ingredient_id"))
                                .SetIngredientName(reader.GetString("ingredient_name"))
                                .SetIngredientQuantity((reader.GetInt32("quantity")))
                                .SetIngredientUnit(reader.GetString("unit"))
                                .Build();
                            im.Add(i);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return im;
        }

        public DataView getIngredientsView()
        {

            string query = @"
                        SELECT 
                            s.ingredient_stock_id AS 'Stock ID' ,
                            i.ingredient_name AS 'Ingredient Name',
                            i.unit AS Unit,
                            s.current_stock AS 'Current Stock',
                            s.expiry_date AS 'Expiry Date',
                            s.created_at AS 'Inserted At'
                        FROM ingredient_stock s
                        JOIN ingredients i ON s.ingredient_id = i.ingredient_id";
            try
            {
                var db = DatabaseHandler.getInstance();
                using (var cmd = new MySqlCommand(query, db.getConnection()))
                {

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return new DataView(dt);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool saveIngredientByMenu(int id, List<IngredientModel> ingredient, string type)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("p_saveIngredientByMenu", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string json = JsonConvert.SerializeObject(ingredient);
                    cmd.Parameters.AddWithValue("@p_id", id);
                    cmd.Parameters.AddWithValue("@p_type", type);
                    cmd.Parameters.AddWithValue("@p_ingredient_json", json);
                    cmd.ExecuteReader();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }

        }
    }
}
