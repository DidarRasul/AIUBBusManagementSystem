using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace AIUBBusManagementSystem.Repositories
{
    internal class UserRepository
    {
        // =====================================================
        // LOGIN
        // =====================================================

        public User GetByUsernameAndPassword(
            string username,
            string password)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM Users
                    WHERE Username = @Username
                      AND Password = @Password";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Username",
                        username);

                    cmd.Parameters.AddWithValue(
                        "@Password",
                        password);

                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                    }
                }
            }

            return null;
        }

        // =====================================================
        // CREATE USER
        // =====================================================

        public int Create(User user)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO Users
                    (
                        Name,
                        Username,
                        Password,
                        Email,
                        Role,
                        Status
                    )
                    OUTPUT INSERTED.Id
                    VALUES
                    (
                        @Name,
                        @Username,
                        @Password,
                        @Email,
                        @Role,
                        @Status
                    )";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Name",
                        user.Name);

                    cmd.Parameters.AddWithValue(
                        "@Username",
                        user.Username);

                    cmd.Parameters.AddWithValue(
                        "@Password",
                        user.Password);

                    cmd.Parameters.AddWithValue(
                        "@Email",
                        user.Email);

                    cmd.Parameters.AddWithValue(
                        "@Role",
                        user.Role);

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        user.Status);

                    con.Open();

                    return Convert.ToInt32(
                        cmd.ExecuteScalar());
                }
            }
        }

        // =====================================================
        // GET USER BY ID
        // =====================================================

        public User GetById(int id)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM Users
                    WHERE Id = @Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Id",
                        id);

                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                    }
                }
            }

            return null;
        }

        // =====================================================
        // GET USERS BY ROLE
        // =====================================================

        public List<User> GetByRole(string role)
        {
            List<User> users =
                new List<User>();

            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM Users
                    WHERE Role = @Role
                    ORDER BY Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Role",
                        role);

                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(
                                MapUser(reader));
                        }
                    }
                }
            }

            return users;
        }

        // =====================================================
        // GET ALL STUDENTS WITH DETAILS
        // =====================================================

        public DataTable GetAllStudentsWithDetails()
        {
            DataTable table =
                new DataTable();

            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        u.Id,
                        u.Name,
                        u.Username,
                        sp.StudentId,
                        sp.Department,
                        sp.Email,
                        u.Status
                    FROM Users u
                    LEFT JOIN StudentProfiles sp
                        ON u.Id = sp.UserId
                    WHERE u.Role = 'Student'
                    ORDER BY u.Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // SEARCH STUDENTS
        // =====================================================

        public DataTable SearchStudentsWithDetails(
            string keyword)
        {
            DataTable table =
                new DataTable();

            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        u.Id,
                        u.Name,
                        u.Username,
                        sp.StudentId,
                        sp.Department,
                        sp.Email,
                        u.Status
                    FROM Users u
                    LEFT JOIN StudentProfiles sp
                        ON u.Id = sp.UserId
                    WHERE u.Role = 'Student'
                      AND
                      (
                           u.Name LIKE @Keyword
                        OR u.Username LIKE @Keyword
                        OR sp.StudentId LIKE @Keyword
                        OR sp.Department LIKE @Keyword
                        OR sp.Email LIKE @Keyword
                      )
                    ORDER BY u.Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Keyword",
                        "%" + keyword.Trim() + "%");

                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // GET ALL DRIVERS WITH DETAILS
        // =====================================================

        public DataTable GetAllDriversWithDetails()
        {
            DataTable table =
                new DataTable();

            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        u.Id,
                        u.Name,
                        u.Username,
                        dp.LicenseNo,
                        dp.Phone,
                        u.Status
                    FROM Users u
                    LEFT JOIN DriverProfiles dp
                        ON u.Id = dp.UserId
                    WHERE u.Role = 'Driver'
                    ORDER BY u.Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // SEARCH DRIVERS
        // =====================================================

        public DataTable SearchDriversWithDetails(
            string keyword)
        {
            DataTable table =
                new DataTable();

            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        u.Id,
                        u.Name,
                        u.Username,
                        dp.LicenseNo,
                        dp.Phone,
                        u.Status
                    FROM Users u
                    LEFT JOIN DriverProfiles dp
                        ON u.Id = dp.UserId
                    WHERE u.Role = 'Driver'
                      AND
                      (
                           u.Name LIKE @Keyword
                        OR u.Username LIKE @Keyword
                        OR dp.LicenseNo LIKE @Keyword
                        OR dp.Phone LIKE @Keyword
                      )
                    ORDER BY u.Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Keyword",
                        "%" + keyword.Trim() + "%");

                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // GET ACTIVE DRIVERS FOR ASSIGNMENT
        // =====================================================

        public DataTable GetActiveDriversForAssignment()
        {
            DataTable table =
                new DataTable();

            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        u.Id,
                        u.Name
                    FROM Users u
                    INNER JOIN DriverProfiles dp
                        ON dp.UserId = u.Id
                    WHERE u.Role = 'Driver'
                      AND u.Status = 'Active'
                    ORDER BY u.Name";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // GET ALL ADMINS
        // =====================================================

        public DataTable GetAllAdmins()
        {
            DataTable table =
                new DataTable();

            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        u.Id,
                        u.Name,
                        u.Username,
                        u.Role,
                        u.Status
                    FROM Users u
                    WHERE u.Role = 'Admin'
                    ORDER BY u.Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // UPDATE USER STATUS
        // =====================================================

        public void UpdateStatus(
            int userId,
            string status)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE Users
                    SET Status = @Status
                    WHERE Id = @Id";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Status",
                        status);

                    cmd.Parameters.AddWithValue(
                        "@Id",
                        userId);

                    con.Open();

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception(
                            "User account was not found.");
                    }
                }
            }
        }

        // =====================================================
        // UPDATE DRIVER STATUS
        // =====================================================

        public void UpdateDriverStatus(
            int driverUserId,
            string status)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE Users
                    SET Status = @Status
                    WHERE Id = @Id
                      AND Role = 'Driver'";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Status",
                        status);

                    cmd.Parameters.AddWithValue(
                        "@Id",
                        driverUserId);

                    con.Open();

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception(
                            "Driver account was not found.");
                    }
                }
            }
        }

        // =====================================================
        // APPROVE ADMIN
        // =====================================================

        public void ApproveAdmin(
            int adminUserId)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE Users
                    SET Status = 'Active'
                    WHERE Id = @Id
                      AND Role = 'Admin'";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Id",
                        adminUserId);

                    con.Open();

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception(
                            "Admin account was not found.");
                    }
                }
            }
        }

        // =====================================================
        // BLOCK ADMIN
        // =====================================================

        public void BlockAdmin(
            int adminUserId)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE Users
                    SET Status = 'Blocked'
                    WHERE Id = @Id
                      AND Role = 'Admin'";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Id",
                        adminUserId);

                    con.Open();

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception(
                            "Admin account was not found.");
                    }
                }
            }
        }

        // =====================================================
        // DELETE USER
        // =====================================================

        public void Delete(int userId)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                con.Open();

                using (SqlTransaction tx =
                       con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd =
                               new SqlCommand(
                                   @"DELETE FROM StudentProfiles
                                     WHERE UserId = @UserId",
                                   con,
                                   tx))
                        {
                            cmd.Parameters.AddWithValue(
                                "@UserId",
                                userId);

                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd =
                               new SqlCommand(
                                   @"DELETE FROM DriverProfiles
                                     WHERE UserId = @UserId",
                                   con,
                                   tx))
                        {
                            cmd.Parameters.AddWithValue(
                                "@UserId",
                                userId);

                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd =
                               new SqlCommand(
                                   @"DELETE FROM AdminProfiles
                                     WHERE UserId = @UserId",
                                   con,
                                   tx))
                        {
                            cmd.Parameters.AddWithValue(
                                "@UserId",
                                userId);

                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd =
                               new SqlCommand(
                                   @"DELETE FROM Users
                                     WHERE Id = @Id",
                                   con,
                                   tx))
                        {
                            cmd.Parameters.AddWithValue(
                                "@Id",
                                userId);

                            int rowsAffected =
                                cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                throw new Exception(
                                    "User account was not found.");
                            }
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // =====================================================
        // FORGOT PASSWORD
        // =====================================================

        public bool UpdatePassword(
            string username,
            string newPassword)
        {
            using (SqlConnection con =
                   DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE Users
                    SET Password = @Password
                    WHERE Username = @Username";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Username",
                        username);

                    cmd.Parameters.AddWithValue(
                        "@Password",
                        newPassword);

                    con.Open();

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // =====================================================
        // MAP USER
        // =====================================================

        private User MapUser(
            SqlDataReader reader)
        {
            return new User
            {
                Id = Convert.ToInt32(
                    reader["Id"]),

                Name =
                    reader["Name"]?.ToString(),

                Username =
                    reader["Username"]?.ToString(),

                Password =
                    reader["Password"]?.ToString(),

                Email =
                    reader["Email"]?.ToString(),

                Role =
                    reader["Role"]?.ToString(),

                Status =
                    reader["Status"]?.ToString()
            };
        }
    }
}