using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<CategoryModel> getCategories()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT DISTINCT c.category_id, c.category_name FROM category c INNER JOIN menu m ON c.category_id = m.category_id WHERE m.isAvailable = 'Yes'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoryModel categoryModel = new CategoryModel(reader.GetInt32("category_id"), reader.GetString("category_name"), ImageHelper.GetImageFromBlob(reader, "menu"));
                            list.Add(categoryModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ehere" + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            list = list
                   .OrderBy(c => c.CategoryName.Equals("Extra", StringComparison.OrdinalIgnoreCase) ? 1 : 0)
                   .ThenBy(c => c.CategoryName)
                   .ToList();
            return list;
        }
    }
}
