using AIUBBusManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIUBBusManagementSystem.Utils;

namespace AIUBBusManagementSystem.Repositories
{
    internal class StudentProfileRepository
    {
        // -------------------------
        // CREATE STUDENT PROFILE
        // -------------------------
        public void Create(StudentProfile profile)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO StudentProfiles (UserId, StudentId, Department, Email)
                    VALUES (@UserId, @StudentId, @Department, @Email)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", profile.UserId);
                cmd.Parameters.AddWithValue("@StudentId", profile.StudentId);
                cmd.Parameters.AddWithValue("@Department", profile.Department);
                cmd.Parameters.AddWithValue("@Email", profile.Email);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // GET PROFILE BY USER ID
        // -------------------------
        public StudentProfile GetByUserId(int userId)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM StudentProfiles
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
        // GET ALL STUDENT PROFILES
        // (Used by Admin)
        // -------------------------
        public List<StudentProfile> GetAll()
        {
            List<StudentProfile> profiles = new List<StudentProfile>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM StudentProfiles";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    profiles.Add(MapProfile(reader));
                }
            }

            return profiles;
        }

        // -------------------------
        // UPDATE STUDENT PROFILE
        // -------------------------
        public void Update(StudentProfile profile)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE StudentProfiles
                    SET StudentId = @StudentId,
                        Department = @Department,
                        Email = @Email
                    WHERE UserId = @UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", profile.StudentId);
                cmd.Parameters.AddWithValue("@Department", profile.Department);
                cmd.Parameters.AddWithValue("@Email", profile.Email);
                cmd.Parameters.AddWithValue("@UserId", profile.UserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // PRIVATE MAPPER
        // -------------------------
        private StudentProfile MapProfile(SqlDataReader reader)
        {
            return new StudentProfile
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                StudentId = reader["StudentId"].ToString(),
                Department = reader["Department"].ToString(),
                Email = reader["Email"].ToString()
            };
        }
    }
}
