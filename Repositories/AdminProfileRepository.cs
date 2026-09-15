using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Utils;
using Microsoft.Data.SqlClient;

namespace AIUBBusManagementSystem.Repositories
{
    internal class AdminProfileRepository
    {
        public void Create(AdminProfile profile)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO AdminProfiles (UserId, AdminId)
                    VALUES (@UserId, @AdminId)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", profile.UserId);
                cmd.Parameters.AddWithValue("@AdminId", profile.AdminId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}