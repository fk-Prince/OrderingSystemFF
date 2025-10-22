using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Coupon
{
    public class CouponRepository : ICouponRepository
    {
        public bool generateCoupon(CouponModel co)
        {
            var db = DatabaseHandler.getInstance();

            try
            {
                var conn = db.getConnection();

                MySqlCommand cmd = new MySqlCommand("p_GenerateCoupon", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_times", co.NumberOfTimes);
                cmd.Parameters.AddWithValue("p_rate", co.CouponRate);
                cmd.Parameters.AddWithValue("p_expiry_date", co.ExpiryDate);
                cmd.Parameters.AddWithValue("p_description", co.Description);
                cmd.ExecuteNonQuery();
                return true;
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

        public CouponModel getCoupon(string code)
        {
            var db = DatabaseHandler.getInstance();

            try
            {
                var conn = db.getConnection();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Coupon WHERE coupon_code = @coupon_code LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@coupon_code", code);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return new CouponModel(
                        reader.GetString("coupon_code"),
                        reader.GetString("status"),
                        reader.GetDouble("rate"),
                        reader.GetDateTime("expiry_Date"),
                         reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString(reader.GetOrdinal("description"))

                       );
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

            return null;
        }


    }
}
