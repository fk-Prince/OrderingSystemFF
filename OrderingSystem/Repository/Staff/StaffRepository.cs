using System;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Staff
{
    public class StaffRepository : IStaffRepository
    {
        public StaffModel successfullyLogin(StaffModel staff)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                string query = "SELECT * FROM staff WHERE username = @username AND password = SHA2(@password, 256)";


                using (var cmd = new MySqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@username", staff.Username);
                    cmd.Parameters.AddWithValue("@password", staff.Password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return StaffModel.Builder()
                                .WithStaffId(reader.GetInt32("staff_id"))
                                .WithUsername(reader.GetString("username"))
                                .WithRole(reader.GetString("role"))
                                .WithFirstName(reader.GetString("firstName"))
                                .WithImage(ImageHelper.GetImageFromBlob(reader, "staff"))
                                .WithLastName(reader.GetString("lastname"))
                                .WithPhoneNumber(!reader.IsDBNull(reader.GetOrdinal("phone")) ? reader.GetString("phone") : "")
                                .WithHiredDate(reader.GetDateTime("hire_date"))
                                .WithStatus(reader.GetString("status"))
                                .Build();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
