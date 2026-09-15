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
    internal class TimeSlotRepository
    {
        // -------------------------
        // GET ALL TIME SLOTS
        // -------------------------
        public List<TimeSlot> GetAll()
        {
            List<TimeSlot> slots = new List<TimeSlot>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM TimeSlots";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    slots.Add(MapSlot(reader));
                }
            }

            return slots;
        }

        // -------------------------
        // GET TIME SLOT BY ID
        // -------------------------
        public TimeSlot GetById(int id)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM TimeSlots WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapSlot(reader);
                }

                return null;
            }
        }

        public List<TimeSlot> GetTimeSlotByDriver(int driverId)
        {
            List<TimeSlot> slots = new List<TimeSlot>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM TimeSlots";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    slots.Add(MapSlot(reader));
                }
            }

            return slots;
        }


        // -------------------------
        // PRIVATE MAPPER
        // -------------------------
        private TimeSlot MapSlot(SqlDataReader reader)
        {
            return new TimeSlot
            {
                Id = Convert.ToInt32(reader["Id"]),
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
        }
    }
}
