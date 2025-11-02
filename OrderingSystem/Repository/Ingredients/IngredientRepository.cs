using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Newtonsoft.Json;
using OrderingSystem.CashierApp.SessionData;
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
        public List<IngredientStockModel> getIngredientsStock()
        {
            string query = @"SELECT iss.*, i.ingredient_name FROM ingredient_stock iss
                             INNER JOIN ingredients i ON i.ingredient_id = iss.ingredient_id
                              WHERE iss.current_stock > 0";
            List<IngredientStockModel> l = new List<IngredientStockModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IngredientStockModel m = IngredientStockModel.Builder()
                                .SetIngredientStockId(reader.GetInt32("ingredient_stock_id"))
                                .SetIngredientName(reader.GetString("ingredient_name"))
                                .SetIngredientQuantity(reader.GetInt32("current_stock"))
                                .Build();
                            l.Add(m);
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
            return l;


        }
        public List<string> getInventoryReasons(string type)
        {
            List<string> im = new List<string>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT DISTINCT reason FROM monitor_inventory WHERE type = @type", conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            im.Add(reader.GetString("reason"));
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
        public bool deductIngredient(int id, int quantity, string reason)
        {
            string query = @"
                        UPDATE ingredient_stock
                        SET current_stock = current_stock - @qty
                        WHERE ingredient_stock_id = @id AND current_stock >= @qty";

            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var transaction = conn.BeginTransaction())
                {
                    using (var cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@qty", quantity);
                        cmd.ExecuteNonQuery();
                    }
                    monitorInventory(id, quantity, reason, transaction, conn, "Deduct");
                    transaction.Commit();
                }
                return true;
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
        public void monitorInventory(int id, int quantity, string reason, MySqlTransaction trans, MySqlConnection conn, string type)
        {
            string query2 = @"INSERT INTO monitor_inventory 
                     (staff_id, ingredient_stock_id, quantity, type,reason)
                     VALUES (@staff_id, @ingredient_stock_id, @quantity, @type,@reason)";

            using (var cmd = new MySqlCommand(query2, conn, trans))
            {
                cmd.Parameters.AddWithValue("@staff_id", SessionStaffData.StaffId);
                cmd.Parameters.AddWithValue("@ingredient_stock_id", id);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.ExecuteNonQuery();
            }
        }
        public bool restockIngredient(int id, int quantity, DateTime value, string reason, string supplierName, double cost)
        {
            string query = @"INSERT INTO ingredient_stock (ingredient_id,current_stock,expiry_date) VALUES (@ingredient_id,@current_stock,@expiry_date)";
            int lastId;
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var transaction = conn.BeginTransaction())
                {
                    using (var cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ingredient_id", id);
                        cmd.Parameters.AddWithValue("@current_stock", quantity);
                        cmd.Parameters.AddWithValue("@expiry_date", value);
                        cmd.ExecuteNonQuery();

                        lastId = (int)cmd.LastInsertedId;
                    }
                    checkSupplier(supplierName, cost, lastId, transaction, conn);
                    monitorInventory(lastId, quantity, reason, transaction, conn, "Add");
                    transaction.Commit();
                }
                return true;
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
        public bool isIngredientNameExists(string name, int id = 0)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                string query = "";
                if (id != 0)
                    query += @"
				        SELECT ingredient_name FROM ingredients 
                        WHERE ingredient_id IN (
                        SELECT oss.ingredient_id FROM ingredient_stock oss
                        INNER JOIN ingredients i ON i.ingredient_id = oss.ingredient_id
                        WHERE oss.ingredient_stock_id <> @ingredient_stock_id AND i.ingredient_name <>  @ingredient_name) AND ingredient_name = @ingredient_name";
                else
                    query += "SELECT 1 FROM ingredients i WHERE @ingredient_name = i.ingredient_name LIMIT 1";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ingredient_name", name);
                    if (id != 0)
                        cmd.Parameters.AddWithValue("@ingredient_stock_id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
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
        }
        public bool addIngredient(string name, int quantity, string unit, DateTime expiry, string supplierName, double cost)
        {
            string query1 = @"INSERT INTO ingredients (ingredient_name,unit) VALUES (@ingredient_name,@unit)";
            string query2 = @"INSERT INTO ingredient_stock (ingredient_id,current_stock,expiry_date) VALUES (@ingredient_id,@current_stock,@expiry_date)";
            int lastId;
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var transaction = conn.BeginTransaction())
                {

                    using (var cmd = new MySqlCommand(query1, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ingredient_name", name);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.ExecuteNonQuery();

                        lastId = (int)cmd.LastInsertedId;
                    }

                    using (var cmd = new MySqlCommand(query2, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ingredient_id", lastId);
                        cmd.Parameters.AddWithValue("@current_stock", quantity);
                        cmd.Parameters.AddWithValue("@expiry_date", expiry);
                        cmd.ExecuteNonQuery();

                        lastId = (int)cmd.LastInsertedId;
                    }
                    checkSupplier(supplierName, cost, lastId, transaction, conn);
                    monitorInventory(lastId, quantity, "Initial-Stock", transaction, conn, "Add");
                    transaction.Commit();
                }
                return true;
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
        private void checkSupplier(string supplierName, double cost, int stock_id, MySqlTransaction trans, MySqlConnection conn)
        {
            string query1 = @"SELECT supplier_id FROM suppliers WHERE supplier_name = @supplier_name";
            string query2 = @"INSERT INTO suppliers (supplier_name) VALUES (@supplier_name)";
            string query3 = @"INSERT INTO supplier_ingredient_stock (ingredient_stock_id,supplier_id,batch_cost) VALUES (@ingredient_stock_id,@supplier_id,@batch_cost)";

            int id = 0;
            using (var cmd = new MySqlCommand(query1, conn, trans))
            {
                cmd.Parameters.AddWithValue("@supplier_name", supplierName);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        id = reader.GetInt32("supplier_id");
                }
            }
            if (id == 0)
            {
                using (var cmd = new MySqlCommand(query2, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@supplier_name", supplierName);
                    cmd.ExecuteNonQuery();
                    id = (int)cmd.LastInsertedId;
                }
            }
            using (var cmd = new MySqlCommand(query3, conn, trans))
            {
                cmd.Parameters.AddWithValue("@ingredient_stock_id", stock_id);
                cmd.Parameters.AddWithValue("@supplier_id", id);
                cmd.Parameters.AddWithValue("@batch_cost", cost);
                cmd.ExecuteNonQuery();
            }
        }
        public bool removeExpiredIngredient()
        {
            string query2 = @"INSERT INTO monitor_inventory 
                     (staff_id, ingredient_stock_id, quantity, type,reason)
                     SELECT @staff_id, ingredient_stock_id, current_stock, 'Deduct', 'Expired'
                     FROM ingredient_stock
                     WHERE expiry_date <= CURDATE() AND current_stock > 0";
            string query = @"
                                UPDATE ingredient_stock
                                SET current_stock = 0
                                WHERE ingredient_stock_id IN (
                                    SELECT ingredient_stock_id
                                    FROM (
                                        SELECT ingredient_stock_id
                                        FROM ingredient_stock
                                        WHERE expiry_date <= CURDATE()
                                    ) AS t
                                )";
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var transaction = conn.BeginTransaction())
                {
                    using (var cmd = new MySqlCommand(query2, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@staff_id", SessionStaffData.StaffId);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                return true;
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
        public bool updateIngredient(int stock_id, string name, string unit)
        {
            string query1 = @"SELECT ingredient_id FROM ingredient_stock WHERE ingredient_stock_id = @ingredient_stock_id LIMIT 1";
            string query2 = @"UPDATE ingredients SET ingredient_name = @ingredient_name, unit = @unit WHERE ingredient_id = @ingredient_id";

            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                int id = 0;
                using (var cmd = new MySqlCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@ingredient_stock_id", stock_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) id = reader.GetInt32("ingredient_id");
                    }
                }
                using (var cmd = new MySqlCommand(query2, conn))
                {
                    cmd.Parameters.AddWithValue("@ingredient_id", id);
                    cmd.Parameters.AddWithValue("@ingredient_name", name);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.ExecuteNonQuery();
                }
                return true;
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

        public List<string> getSuppliers()
        {
            List<string> im = new List<string>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT DISTINCT supplier_name FROM suppliers", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            im.Add(reader.GetString("supplier_name"));
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
    }
}
