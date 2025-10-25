using System;
using System.Data;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;

namespace OrderingSystem.Repository.Reports
{
    public class InventoryReportsRepository : IInventoryReportsRepository
    {
        public DataView getInventoryReports()
        {
            string query = @"
                        SELECT
                            CONCAT(
                                UPPER(SUBSTRING(s.firstName, 1, 1)), LOWER(SUBSTRING(s.firstName, 2)),
                                ' ',
                                UPPER(SUBSTRING(s.lastName, 1, 1)), LOWER(SUBSTRING(s.lastName, 2))
                            ) AS 'Staff Incharge',
                            i.ingredient_name AS 'Ingredient Name',
                            oss.current_stock AS 'Current Stock',
                            (mi.quantity - oss.current_stock - COALESCE(d.quantity, 0)) AS 'Used',
                            COALESCE(d.quantity, 0) AS 'Deductions',
	                        COALESCE(d.reasons,'') AS 'Deductions Reason',
                            oss.expiry_date AS 'Expiry Date',
                            mi.created_at AS 'IN - Recorded At'
                        FROM monitor_inventory mi
                        INNER JOIN staff s ON s.staff_id = mi.staff_id
                        INNER JOIN ingredient_stock oss ON oss.ingredient_stock_id = mi.ingredient_stock_id
                        INNER JOIN ingredients i ON i.ingredient_id = oss.ingredient_id
                        LEFT JOIN (
                            SELECT ingredient_stock_id, SUM(quantity) AS quantity, CONCAT('(',COUNT(*),') ' , GROUP_CONCAT(reason SEPARATOR ', ')) AS reasons 
                            FROM monitor_inventory
                            WHERE type = 'Deduct'
                            GROUP BY ingredient_stock_id
                        ) d ON d.ingredient_stock_id = mi.ingredient_stock_id
                        WHERE mi.type = 'Add'
                        ORDER BY mi.created_at;
                        ";

            var db = DatabaseHandler.getInstance();
            DataTable dt = new DataTable();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                DataView view = new DataView(dt);
                return view;
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
        public DataView getIngredientExpiry()
        {

            string query = @"
                        SELECT
                            i.ingredient_name AS 'Ingredient Name',
                            oss.current_stock AS 'Current Stock',
                            oss.expiry_date AS 'Expiry Date',
                            mi.created_at AS 'IN - Recorded At'
                        FROM monitor_inventory mi
                        INNER JOIN ingredient_stock oss ON oss.ingredient_stock_id = mi.ingredient_stock_id
                        INNER JOIN ingredients i ON i.ingredient_id = oss.ingredient_id
                        LEFT JOIN (
                            SELECT ingredient_stock_id, SUM(quantity) quantity, CONCAT('(',COUNT(*),') ' , GROUP_CONCAT(reason SEPARATOR ', ')) AS reasons 
                            FROM monitor_inventory
                            WHERE type = 'Deduct'
                            GROUP BY ingredient_stock_id
                        ) d ON d.ingredient_stock_id = mi.ingredient_stock_id
                        WHERE mi.type = 'Add'
                        ORDER BY mi.created_at;
                        ";

            var db = DatabaseHandler.getInstance();
            DataTable dt = new DataTable();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                DataView view = new DataView(dt);
                return view;
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
        public DataView getIngredientTrackerView()
        {
            var db = DatabaseHandler.getInstance();
            DataTable dt = new DataTable();
            try
            {
                string query = @"
                    SELECT 
                       CONCAT(
                           UPPER(SUBSTRING(s.firstName, 1, 1)), LOWER(SUBSTRING(s.firstName, 2)),
                           ' ',
                           UPPER(SUBSTRING(s.lastName, 1, 1)), LOWER(SUBSTRING(s.lastName, 2)) 
                        ) AS 'Staff Incharge',
                        i.ingredient_name as 'Ingredient Name',
                        mi.quantity as Quantity, 
                        mi.type as Movement, 
                        mi.reason as Reason, 
                        mi.created_at as 'Date-Action'
                    FROM monitor_inventory mi 
                    INNER JOIN staff s ON s.staff_id = mi.staff_id
                    INNER JOIN ingredient_stock oss ON oss.ingredient_stock_id = mi.ingredient_stock_id
                    INNER JOIN ingredients i ON i.ingredient_id = oss.ingredient_id
                    ORDER BY mi.created_at";

                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                DataView view = new DataView(dt);
                return view;
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
        public DataView getIngredientsUsage()
        {
            string query = @"
                    SELECT 
                        v.ingredient_name AS 'Ingredient Name', 
                        SUM(v.total_used) as 'Total Used'
                    FROM (
                        SELECT 
                          i.ingredient_id,
                          i.ingredient_name,
                          SUM(mi.quantity * oi.quantity) AS total_used
                        FROM menu_order_regular mor
                        LEFT JOIN order_item oi ON mor.order_item_id = oi.order_item_id
                        INNER JOIN orders o ON o.order_id = oi.order_id
                        LEFT JOIN menu_detail md ON mor.menu_detail_id = md.menu_detail_id
                        LEFT JOIN menu_ingredient mi ON md.menu_detail_id = mi.menu_detail_id
                        LEFT JOIN ingredients i ON mi.ingredient_id = i.ingredient_id
                        WHERE LOWER(o.status) = 'paid'
                        GROUP BY i.ingredient_name,  i.ingredient_id

                        UNION ALL

                        SELECT 
                          i.ingredient_id,
                          i.ingredient_name,
                          SUM(mi.quantity * oi.quantity) AS total_used
                        FROM menu_order_package mop
                        LEFT JOIN order_item oi ON mop.order_item_id = oi.order_item_id
                        INNER JOIN orders o ON o.order_id = oi.order_id
                        LEFT JOIN menu_detail md ON mop.from_menu_detail_id = md.menu_detail_id
                        LEFT JOIN menu_ingredient mi ON md.menu_detail_id = mi.menu_detail_id
                        LEFT JOIN ingredients i ON mi.ingredient_id = i.ingredient_id
                        WHERE LOWER(o.status) = 'paid'
                        GROUP BY i.ingredient_name,  i.ingredient_id
                    ) as v
                    GROUP BY v.ingredient_id, v.ingredient_name
                    ";

            var db = DatabaseHandler.getInstance();
            DataTable dt = new DataTable();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                DataView view = new DataView(dt);
                return view;
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
        public DataView getMenuPopularity()
        {
            string query = @"
                   SELECT 
                        v.menu_name AS 'Menu Name',
                        SUM(v.total_orders) AS 'Total Orders',
                        SUM(v.total_sold) AS 'Total Sold',
                        SUM(v.total_pending) AS 'Order Pending',
                        SUM(v.total_cancelled) AS 'Total Cancelled'
                    FROM (
                        SELECT 
                            m.menu_name,
                            COUNT(mor.menu_detail_id) AS total_orders,
                            SUM(CASE WHEN LOWER(o.status) = 'paid' THEN COALESCE(oi.quantity, 0) ELSE 0 END) AS total_sold,
                            SUM(CASE WHEN LOWER(o.status) = 'pending' THEN COALESCE(oi.quantity, 0) ELSE 0 END) AS total_pending,
                            SUM(CASE WHEN LOWER(o.status) = 'cancelled' THEN COALESCE(oi.quantity, 0) ELSE 0 END) AS total_cancelled,
                            DATE(i.created_at) AS created_date
                        FROM menu_order_regular mor
                        INNER JOIN order_item oi ON mor.order_item_id = oi.order_item_id
                        INNER JOIN orders o ON o.order_id = oi.order_id
                        INNER JOIN menu_detail md ON mor.menu_detail_id = md.menu_detail_id
                        INNER JOIN menu m ON md.menu_id = m.menu_id
                        LEFT JOIN invoice i ON i.order_id = o.order_id
                        GROUP BY m.menu_name, DATE(i.created_at)

                        UNION ALL 

                        SELECT 
                            m.menu_name,
                            COUNT(mor.from_menu_detail_id) AS total_orders,
                          SUM(CASE WHEN LOWER(o.status) = 'paid' THEN COALESCE(oi.quantity, 0) ELSE 0 END) AS total_sold,
		                    SUM(CASE WHEN LOWER(o.status) = 'pending' THEN COALESCE(oi.quantity, 0) ELSE 0 END) AS total_pending,
                            SUM(CASE WHEN LOWER(o.status) = 'cancelled' THEN COALESCE(oi.quantity, 0) ELSE 0 END) AS total_cancelled,
                            DATE(i.created_at) AS created_date
                        FROM menu_order_package mor
                        INNER JOIN order_item oi ON mor.order_item_id = oi.order_item_id
                        INNER JOIN orders o ON o.order_id = oi.order_id
                        INNER JOIN menu_detail md ON mor.from_menu_detail_id = md.menu_detail_id
                        INNER JOIN menu m ON md.menu_id = m.menu_id
                        LEFT JOIN invoice i ON i.order_id = o.order_id
                        GROUP BY m.menu_name, DATE(i.created_at)
                    ) AS v
                    GROUP BY v.menu_name, v.created_date
                    ORDER BY SUM(v.total_sold) DESC;
                    ";

            var db = DatabaseHandler.getInstance();
            DataTable dt = new DataTable();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                DataView view = new DataView(dt);
                return view;
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
        public DataView getMenuPerformance()
        {
            string query = @"
                            SELECT 
                              m.menu_name AS 'Menu Name',
                              md.size_name AS 'Size',
                              md.flavor_name AS 'Flavor',
                              md.price AS 'Price',
                              SUM(oi.quantity) AS 'Total Sold',
                              SUM(oi.quantity * md.price) AS 'Revenue'
                            FROM menu_order_regular mor
                            JOIN order_item oi ON mor.order_item_id = oi.order_item_id
                            JOIN menu_detail md ON mor.menu_detail_id = md.menu_detail_id
                            JOIN menu m ON md.menu_id = m.menu_id
                            JOIN orders o ON oi.order_id = o.order_id
                            WHERE o.status = 'Paid'
                            GROUP BY m.menu_name,
                              md.size_name,
                              md.flavor_name,
                              md.price
                            ORDER BY Revenue DESC;
                            ";

            var db = DatabaseHandler.getInstance();
            DataTable dt = new DataTable();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                DataView view = new DataView(dt);
                return view;
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
