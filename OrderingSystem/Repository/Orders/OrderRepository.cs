﻿using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Newtonsoft.Json;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Order
{
    public class OrderRepository : IOrderRepository
    {
        public bool getOrderAvailable(string order_id)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) as c FROM orders WHERE order_id = @order_id AND available_until > NOW()", conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32("c") > 0;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return false;
        }
        public bool getOrderExists(string order_id)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) as c FROM orders WHERE order_id = @order_id", conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32("c") > 0;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return false;
        }
        public OrderModel getOrders(string order_id)
        {
            List<OrderItemModel> oim = new List<OrderItemModel>();
            var db = DatabaseHandler.getInstance();
            double couponRate = 0;
            string orderId = "";

            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("p_retrieve_order", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_order_id", order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderItemModel m = OrderItemModel.Builder()
                                .WithMenuName(reader.GetString("menu_name"))
                                .WithFlavorName(reader.GetString("flavor_name"))
                                .WithSizeName(reader.GetString("size_name"))
                                .WithPurchaseQty(reader.GetInt32("quantity"))
                                .WithPrice(reader.GetDouble("price"))
                                .WithOrderItemId(reader.GetInt32("order_item_id"))
                                //.WithNote(reader.GetString("order_note"))
                                //.WithNoteApproved(reader.GetBoolean("note_approve"))
                                .Build();
                            oim.Add(m);

                            if (string.IsNullOrEmpty(orderId))
                            {
                                orderId = reader.GetString("order_id");
                                couponRate = reader.GetDouble("coupon_rate");
                            }

                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            OrderModel om = OrderModel.Builder()
                                .SetOrderId(orderId)
                                .SetCouponRate(couponRate)
                                .SetOrderItemModel(oim)
                                .Build();

            return om;
        }
        public bool saveNewOrder(OrderModel order)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("p_NewOrder", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_json_orderList", order.JsonOrderList());
                    if (order.Coupon != null)
                        cmd.Parameters.AddWithValue("@p_coupon_code", order.Coupon.CouponCode);
                    else
                        cmd.Parameters.AddWithValue("@p_coupon_code", DBNull.Value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
        }
        public bool payOrder(OrderModel order, int staff_id, string payment_method)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("p_Confirm_Payment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string json = JsonConvert.SerializeObject(order);
                    cmd.Parameters.AddWithValue("@p_order_json", json);
                    cmd.Parameters.AddWithValue("@p_staff_id", staff_id);
                    cmd.Parameters.AddWithValue("@p_payment_method ", payment_method);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }

        }
        public bool isOrderPayed(string order_id)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT * FROM orders WHERE status = 'Paid' AND order_id = @order_id", conn))
                {
                    cmd.Parameters.AddWithValue("@order_id ", order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }

                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return false;
        }
        public string getOrderId()
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("p_GenerateNextOrderId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var p = new MySqlParameter("p_order_id", MySqlDbType.VarChar, 255);
                    p.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();
                    return p.Value.ToString();
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
        }
        public List<string> getAvailablePayments()
        {
            List<string> p = new List<string>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT * FROM payment_method WHERE isActive = 'Active'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p.Add(reader.GetString("payment_type"));
                        }
                        return p;
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
        }
        public Tuple<TimeSpan, string> getTimeInvoiceWaiting(string order_id)
        {
            string query = @"
                        SELECT
                        o.estimated_max_time, 
                        i.invoice_id
                        FROM orders o
                        INNER JOIN invoice i ON i.order_id = o.order_id
                        WHERE @order_id = o.order_id
                        ";
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan estimatedTime = reader.GetTimeSpan("estimated_max_time");
                            string invoiceId = reader.GetString("invoice_id");

                            return new Tuple<TimeSpan, string>(estimatedTime, invoiceId);
                        }

                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return null;
        }
    }
}
