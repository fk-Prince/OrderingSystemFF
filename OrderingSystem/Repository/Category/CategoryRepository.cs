using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool createCategory(CategoryModel c)
        {

            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("INSERT INTO category (category_name, image) VALUES (@category_name,@image)", conn))
                {
                    cmd.Parameters.AddWithValue("@category_name", c.CategoryName);
                    if (c.CategoryImage != null)
                        cmd.Parameters.AddWithValue("@image", ImageHelper.GetImageFromFile(c.CategoryImage));
                    else
                        cmd.Parameters.AddWithValue("@image", DBNull.Value);
                    cmd.ExecuteNonQuery();
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
        public List<CategoryModel> getCategoriesByMenu()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT DISTINCT c.category_id, c.category_name, c.image FROM category c INNER JOIN menu m ON c.category_id = m.category_id", conn))
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
            catch (Exception)
            {
                throw;
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
        public List<CategoryModel> getCategories()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT DISTINCT c.category_id, c.category_name, c.image FROM category c", conn))
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
            catch (Exception)
            {
                throw;
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
        public bool isCategoryNameExists(CategoryModel c)
        {

            var db = DatabaseHandler.getInstance();
            try
            {
                string query = "SELECT c.category_name FROM category c WHERE c.category_name = @category_name";
                if (c.CategoryId != 0)
                    query += " AND c.category_id != @category_id";

                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@category_name", c.CategoryName);
                    if (c.CategoryId != 0)
                        cmd.Parameters.AddWithValue("@category_id", c.CategoryId);
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
        public bool updateCategory(CategoryModel c)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                string query = "UPDATE category SET category_name = @category_name, image = @image WHERE category_id = @category_id";
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@category_name", c.CategoryName);
                    if (c.CategoryImage != null)
                        cmd.Parameters.AddWithValue("@image", ImageHelper.GetImageFromFile(c.CategoryImage));
                    else
                        cmd.Parameters.AddWithValue("@image", DBNull.Value);
                    cmd.Parameters.AddWithValue("@category_id", c.CategoryId);
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
    }
}
