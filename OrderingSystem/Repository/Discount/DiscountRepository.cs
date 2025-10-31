using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Discount
{
    public class DiscountRepository : IDiscountRepository
    {
        public List<DiscountModel> GetDiscount()
        {
            List<DiscountModel> l = new List<DiscountModel>();
            var db = DatabaseHandler.getInstance();

            try
            {
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand("SELECT * FROM discount", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var discount = DiscountModel.Builder()
                                .WithDiscountId(reader.GetInt32("discount_id"))
                                .WithRate(reader.GetDouble("rate"))
                                .WithUntilDate(reader.GetDateTime("until_date"))
                                .Build();
                            l.Add(discount);
                        }
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return l;
        }

        public bool SaveDate(double rate, DateTime date)
        {
            var db = DatabaseHandler.getInstance();

            try
            {
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand("INSERT INTO discount (rate,until_date) VALUES (@rate,@until_date)", conn))
                {
                    cmd.Parameters.AddWithValue("@rate", rate);
                    cmd.Parameters.AddWithValue("@until_date", date);
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return false;
        }
    }
}
