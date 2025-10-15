using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using Newtonsoft.Json;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public class KioskMenuRepository : IKioskMenuRepository
    {
        private List<MenuModel> orderList;
        public KioskMenuRepository(List<MenuModel> orderList)
        {
            this.orderList = orderList;
        }
        public List<MenuModel> getMenu()
        {
            List<MenuModel> list = new List<MenuModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT * FROM view_menu WHERE isAvailable = 'Yes'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var menu = MenuModel.Builder()
                                .WithMenuId(reader.GetInt32("menu_id"))
                                .WithMenuName(reader.GetString("menu_name"))
                                .WithMenuDescription(reader.GetString("menu_description"))
                                .WithMenuDetailId(reader.GetInt32("menu_detail_id"))
                                .WithPrice(reader.GetDouble("min_price"))
                                .WithCategoryId(reader.GetInt32("category_id"))
                                .WithDiscountId(reader.GetInt32("discount_id"))
                                .WithDiscountMenuRate(reader.GetDouble("discount_rate"))
                                .WithMenuImage(ImageHelper.GetImageFromBlob(reader))
                                .Build();
                            list.Add(menu);
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
            return list;
        }
        public List<MenuModel> getDetails(MenuModel menu)
        {
            var db = DatabaseHandler.getInstance();
            List<MenuModel> mds = new List<MenuModel>();
            try
            {
                var conn = db.getConnection();
                string query = @"                        
                                  SELECT 
                                      md.menu_id,
                                      m.menu_name,
                                      m.image,
                                      md.menu_detail_id,
                                      md.price,
                                      f.flavor_name,
                                      s.size_name,
                                      COALESCE(d.rate,0) discount_rate,
                                      COALESCE(d.discount_id,0) discount_id,
                                      md.estimated_time
                                  FROM menu m
                                  LEFT JOIN menu_discount mdc ON m.menu_id = mdc.menu_id
                                  LEFT JOIN discount d ON d.discount_id = mdc.discount_id AND d.until_date > NOW()
                                  LEFT JOIN category c ON m.category_id = c.category_id
                                  LEFT JOIN menu_detail md ON m.menu_id = md.menu_id
                                  LEFT JOIN flavor f ON f.flavor_id = md.flavor_id
                                  LEFT JOIN size s ON s.size_id = md.size_id
                                  WHERE m.isAvailable = 'Yes' 
                                    AND m.menu_id = @menu_id
                                    AND md.menu_detail_id NOT IN (SELECT from_menu_detail_id FROM menu_package)
                                  ORDER BY md.price ASC;
                     ";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", menu.MenuId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maxOrder = getMaxOrderRealTime(reader.GetInt32("menu_detail_id"), orderList);
                            mds.Add(MenuModel.Builder()
                                .WithMenuId(reader.GetInt32("menu_id"))
                                .WithMenuDetailId(reader.GetInt32("menu_detail_id"))
                                .WithPrice(reader.GetDouble("price"))
                                .WithMenuName(reader.GetString("menu_name"))
                                .WithMenuImage(ImageHelper.GetImageFromBlob(reader))
                                .WithDiscountMenuRate(reader.GetDouble("discount_rate"))
                                .WithEstimatedTime(reader.GetTimeSpan("estimated_time"))
                                .WithMaxOrder(maxOrder)
                                .WithDiscountId(reader.GetInt32("discount_id"))
                                .WithFlavorName(reader.GetString("flavor_name"))
                                .WithSizeName(reader.GetString("size_name"))
                                .Build());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " xdxd");
                Console.WriteLine("error on getMenuDetailFlavor");
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return mds;
        }
        public int getMaxOrderRealTime(int menu_id, List<MenuModel> orderList)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand("p_menu_max_order", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string json = JsonConvert.SerializeObject(orderList);
                    cmd.Parameters.AddWithValue("@p_menu_detail_id", menu_id);
                    cmd.Parameters.AddWithValue("@p_json", json);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32("max_order");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "123");
                Console.WriteLine("error on getMaxOrderRealTime");
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return 0;
        }
        public bool isMenuPackage(MenuModel menu)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                string query = @"
                                SELECT COUNT(*) c FROM menu m
                                INNER JOIN menu_detail md ON m.menu_id = md.menu_id
                                WHERE md.menu_detail_id IN (
	                                SELECT pg.from_menu_detail_id FROM menu_package pg 
                                ) AND m.menu_id = @menu_id;
                                ";
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", menu.MenuId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32("c") >= 1;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("error on isMenuPackage");
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return false;
        }
        public List<MenuModel> getFrequentlyOrderedTogether(MenuModel menus)
        {
            List<MenuModel> list = new List<MenuModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("p_retrieve_FrequentlyOrderedTogether", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_menu_id", menus.MenuId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int discount_id = reader.GetOrdinal("discount_id");
                            var menu = MenuModel.Builder()
                                .WithMenuId(reader.GetInt32("menu_id"))
                                .WithMenuName(reader.GetString("menu_name"))
                                .WithMenuDescription(reader.GetString("menu_description"))
                                .WithMenuDetailId(reader.GetInt32("menu_detail_id"))
                                .WithPrice(reader.GetDouble("price"))
                                .WithDiscountId(reader.IsDBNull(discount_id) ? 0 : reader.GetInt32(discount_id))
                                .WithDiscountMenuRate(reader.GetDouble("discount_rate"))
                                .WithMenuImage(ImageHelper.GetImageFromBlob(reader))
                                .Build();
                            list.Add(menu);
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
            return list;
        }
        public List<MenuModel> getIncludedMenu(MenuModel menu)
        {
            List<MenuModel> list = new List<MenuModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                string query = @"
                             WITH RECURSIVE package_items AS (
                                SELECT
                                    mp.included_menu_detail_id,
                                    mp.quantity,
                                    mp.package_type,
                                    1 AS item_number
                                FROM menu_package mp
                                JOIN menu_detail md_package ON mp.from_menu_detail_id = md_package.menu_detail_id
                                WHERE md_package.menu_id = @menu_id 
                                UNION ALL
                                SELECT
                                    p.included_menu_detail_id,
                                    p.quantity,
                                    p.package_type,    
                                    p.item_number + 1
                                FROM package_items p
                                WHERE p.item_number < p.quantity
                                      
                            )
                            SELECT
                                md.menu_id,
                                md.menu_detail_id,
                                m.menu_name,
                                m.menu_description,
                                f.flavor_name,
                                s.size_name,
                                md.price,
                                COALESCE(d.rate, 0) discount_rate,
                                COALESCE(d.discount_id, 0) discount_id,
                                pi.quantity,
                                pi.package_type
                            FROM package_items pi
                            JOIN menu_detail md ON pi.included_menu_detail_id = md.menu_detail_id
                            LEFT JOIN menu m ON md.menu_id = m.menu_id
                            LEFT JOIN menu_discount mdc ON md.menu_id = mdc.menu_id
                            LEFT JOIN discount d ON d.discount_id = mdc.discount_id
                            LEFT JOIN flavor f ON f.flavor_id = md.flavor_id
                            LEFT JOIN size s ON s.size_id = md.size_id
                            ORDER BY
                                md.menu_id, 
                                f.flavor_name;";
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", menu.MenuId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int max = getMaxOrderRealTime(reader.GetInt32("menu_detail_id"), orderList);
                            var x = MenuPackageModel.Builder()
                               .WithMenuId(reader.GetInt32("menu_id"))
                               .isFixed(reader.GetString("package_type") == "Fixed" ? true : false)
                               .WithMenuName(reader.GetString("menu_name"))
                               .WithMenuDescription(reader.GetString("menu_description"))
                               .WithMenuDetailId(reader.GetInt32("menu_detail_id"))
                               .WithPrice(reader.GetDouble("price"))
                               .WithSizeName(reader.GetString("size_name"))
                               .WithFlavorName(reader.GetString("flavor_name"))
                               .WithDiscountId(reader.GetInt32("discount_id"))
                               .WithDiscountMenuRate(reader.GetDouble("discount_rate"))
                               .WithMenuImage(ImageHelper.GetImageFromBlob(reader))
                               .Build();
                            list.Add(x);
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("error on getMenuId");
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return list;
        }
        public List<MenuModel> getDetailsByPackage(MenuModel menu)
        {
            var db = DatabaseHandler.getInstance();
            List<MenuModel> mds = new List<MenuModel>();
            try
            {
                var conn = db.getConnection();
                string query = @"                                                 
                            SELECT 
                                md.menu_id,
                                md.menu_detail_id,
                                md.price,
                                f.flavor_name,
                                s.size_name,
                                COALESCE(d.discount_id, 0) AS discount_id,
                                COALESCE(d.rate, 0) AS discount_rate,
                                COALESCE(mp.package_type, 'Not-Fixed') AS package_type
                            FROM menu m
                            LEFT JOIN menu_discount mdc ON m.menu_id = mdc.menu_id
                            LEFT JOIN discount d ON d.discount_id = mdc.discount_id
                            LEFT JOIN category c ON m.category_id = c.category_id
                            LEFT JOIN menu_detail md ON m.menu_id = md.menu_id
                            LEFT JOIN flavor f ON f.flavor_id = md.flavor_id
                            LEFT JOIN size s ON s.size_id = md.size_id
                            LEFT JOIN (SELECT from_menu_detail_id, package_type FROM menu_package) mp ON mp.from_menu_detail_id = md.menu_detail_id
                            WHERE m.isAvailable = 'Yes' 
                              AND m.menu_id = @menu_id
                             AND (
                                  mp.package_type IS NULL  
                                  OR
                                  (mp.package_type <> 'fixed')  
                                  OR
                                  (mp.package_type = 'fixed' AND md.menu_detail_id = @id)  
                              )
                            ORDER BY 
                              CASE WHEN md.menu_detail_id = @id THEN 0 ELSE 1 END,
                              md.menu_detail_id; 
                                        ";
                using (var cmd = new MySqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@menu_id", menu.MenuId);
                    cmd.Parameters.AddWithValue("@id", menu.MenuDetailId);
                    //cmd.Parameters.AddWithValue("@flavor_name", md.FlavorName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maxOrder = getMaxOrderRealTime(reader.GetInt32("menu_detail_id"), orderList);
                            mds.Add(MenuPackageModel.Builder()
                               .WithMenuId(reader.GetInt32("menu_id"))
                               .WithMenuDetailId(reader.GetInt32("menu_detail_id"))
                               .WithPrice(reader.GetDouble("price"))
                               .WithDiscountMenuRate(reader.GetDouble("discount_rate"))
                               .WithDiscountId(reader.GetInt32("discount_id"))
                               .isFixed(reader.GetString("package_type") == "Fixed" ? true : false)
                               .WithMaxOrder(maxOrder)
                               .WithFlavorName(reader.GetString("flavor_name"))
                               .WithSizeName(reader.GetString("size_name"))
                               .Build());

                        }
                    }
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("error on getMenuDetailFlavorPackage");
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return mds;
        }
        public MenuModel getSelectedMenu(int menu_id, string flavorName, string sizeName)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                string query = @"
                                 SELECT
                                        md.menu_detail_id,
                                        md.price,
                                        f.flavor_name,
                                        s.size_name,
                                        md.estimated_time,
                                        m.*,
                                        d.discount_id,
                                        COALESCE(d.rate,0) discount_rate 
                                 FROM menu_detail md
                                 INNER JOIN menu m ON m.menu_id = md.menu_id
                                 LEFT JOIN menu_discount mdc ON mdc.menu_id = m.menu_id
                                 LEFT JOIN discount d ON d.discount_id = mdc.discount_id
                                 LEFT JOIN flavor f ON f.flavor_id = md.flavor_id
                                 LEFT JOIN size s ON s.size_id = md.size_id
                                 WHERE md.menu_id = @menu_id";

                if (!string.IsNullOrWhiteSpace(flavorName))
                    query += " AND LOWER(f.flavor_name) = LOWER(@flavor_name)";


                if (!string.IsNullOrWhiteSpace(sizeName))
                    query += " AND LOWER(s.size_name) = LOWER(@size_name)";

                query += " ORDER BY md.menu_detail_id LIMIT 1";

                var conn = db.getConnection();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", menu_id);
                    if (!string.IsNullOrWhiteSpace(flavorName))
                        cmd.Parameters.AddWithValue("@flavor_name", flavorName);

                    if (!string.IsNullOrWhiteSpace(sizeName))
                        cmd.Parameters.AddWithValue("@size_name", sizeName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int discountId = reader.IsDBNull(reader.GetOrdinal("discount_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("discount_id"));
                            return MenuModel.Builder()
                                .WithMenuId(reader.GetInt32("menu_id"))
                                .WithMenuDescription(reader.GetString("menu_description"))
                                .WithMenuName(reader.GetString("menu_name"))
                                .WithPrice(reader.GetDouble("price"))
                                .WithFlavorName(reader.GetString("flavor_name"))
                                .WithSizeName(reader.GetString("size_name"))
                                .WithMenuDetailId(reader.GetInt32("menu_detail_id"))
                                .WithDiscountMenuRate(reader.GetDouble("discount_rate"))
                                .WithDiscountId(discountId)
                                .Build();
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("error on getSelectedMenu");
                throw;
            }
            finally
            {
                db.closeConnection();
            }

            return null;
        }
        public double getNewPackagePrice(int menuid, List<MenuModel> selectedMenus)
        {
            var db = DatabaseHandler.getInstance();

            try
            {
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand("p_menu_package_price", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string json = JsonConvert.SerializeObject(selectedMenus);
                    Console.WriteLine(json);
                    MessageBox.Show(menuid.ToString());
                    cmd.Parameters.AddWithValue("@p_package_id", menuid);
                    cmd.Parameters.AddWithValue("@p_included", json);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal d = reader.GetDecimal(0);
                            return (double)d;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "123");
                Console.WriteLine("error on getNewPackagePrice");
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return 0;
        }
    }
}
