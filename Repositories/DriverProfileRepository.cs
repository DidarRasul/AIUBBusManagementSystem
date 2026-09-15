using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Utils;
using AIUBBusManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Repositories
{
    internal class DriverProfileRepository
    {
        // -------------------------
        // CREATE DRIVER PROFILE
        // -------------------------
        public void Create(DriverProfile profile)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO DriverProfiles (UserId, LicenseNo, Phone)
                    VALUES (@UserId, @LicenseNo, @Phone)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", profile.UserId);
                cmd.Parameters.AddWithValue("@LicenseNo", profile.LicenseNo);
                cmd.Parameters.AddWithValue("@Phone", profile.Phone);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // GET DRIVER PROFILE BY USER ID
        // -------------------------
        public DriverProfile GetByUserId(int userId)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM DriverProfiles
                    WHERE UserId = @UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapProfile(reader);
                }

                return null;
            }
        }

        // -------------------------
        // UPDATE DRIVER PROFILE
        // -------------------------
        public void Update(DriverProfile profile)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE DriverProfiles
                    SET LicenseNo = @LicenseNo,
                        Phone = @Phone
                    WHERE UserId = @UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LicenseNo", profile.LicenseNo);
                cmd.Parameters.AddWithValue("@Phone", profile.Phone);
                cmd.Parameters.AddWithValue("@UserId", profile.UserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // PRIVATE MAPPER
        // -------------------------
        private DriverProfile MapProfile(SqlDataReader reader)
        {
            return new DriverProfile
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                LicenseNo = reader["LicenseNo"].ToString(),
                Phone = reader["Phone"].ToString()
            };
        }
    }
}
