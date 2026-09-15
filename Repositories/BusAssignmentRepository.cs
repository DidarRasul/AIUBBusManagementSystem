using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Repositories
{
    internal class BusAssignmentRepository
    {
        // -------------------------
        // CREATE BUS ASSIGNMENT
        // -------------------------
        public void Create(BusAssignment assignment)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO BusAssignments
                    (RouteId, DriverId, BusId, TimeSlotId, Date)
                    VALUES (@RouteId, @DriverId, @BusId, @TimeSlotId, @Date)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RouteId", assignment.RouteId);
                cmd.Parameters.AddWithValue("@DriverId", assignment.DriverId);
                cmd.Parameters.AddWithValue("@BusId", assignment.BusId);
                cmd.Parameters.AddWithValue("@TimeSlotId", assignment.TimeSlotId);
                cmd.Parameters.AddWithValue("@Date", assignment.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // GET ASSIGNMENTS BY DATE
        // -------------------------
        public List<BusAssignment> GetByDate(DateTime date)
        {
            List<BusAssignment> assignments = new List<BusAssignment>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM BusAssignments
                    WHERE Date = @Date";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Date", date.Date);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    assignments.Add(MapAssignment(reader));
                }
            }

            return assignments;
        }

        // -------------------------
        // GET ASSIGNMENTS BY DRIVER & DATE
        // -------------------------
        public List<BusAssignment> GetByDriver(int driverId, DateTime date)
        {
            List<BusAssignment> assignments = new List<BusAssignment>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM BusAssignments
                    WHERE DriverId = @DriverId
                      AND Date = @Date";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DriverId", driverId);
                cmd.Parameters.AddWithValue("@Date", date.Date);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    assignments.Add(MapAssignment(reader));
                }
            }

            return assignments;
        }

        // -------------------------
        // GET ASSIGNMENT BY ID
        // -------------------------
        public BusAssignment GetById(int id)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM BusAssignments WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapAssignment(reader);
                }

                return null;
            }
        }

        // -------------------------
        // PRIVATE MAPPER
        // -------------------------
        private BusAssignment MapAssignment(SqlDataReader reader)
        {
            return new BusAssignment
            {
                Id = Convert.ToInt32(reader["Id"]),
                RouteId = Convert.ToInt32(reader["RouteId"]),
                DriverId = Convert.ToInt32(reader["DriverId"]),
                BusId = Convert.ToInt32(reader["BusId"]),
                TimeSlotId = Convert.ToInt32(reader["TimeSlotId"]),
                Date = Convert.ToDateTime(reader["Date"])
            };
        }

        // -------------------------
        // GET ASSIGNMENTS BY DATE WITH DETAILS
        // -------------------------
        public DataTable GetByDateWithDetails(DateTime date)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT
                        ba.Id,
                        ba.Date,
                        b.BusName,
                        r.RouteName,
                        u.Name AS DriverName,
                        CONVERT(varchar(5), ts.StartTime, 108) + ' - ' + CONVERT(varchar(5), ts.EndTime, 108) AS TimeSlot
                    FROM BusAssignments ba
                    INNER JOIN Buses b ON b.Id = ba.BusId
                    INNER JOIN Routes r ON r.Id = ba.RouteId
                    INNER JOIN Users u ON u.Id = ba.DriverId
                    INNER JOIN TimeSlots ts ON ts.Id = ba.TimeSlotId
                    ORDER BY ba.Date, ts.StartTime;";

                using SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // -------------------------
        // GET AVAILABLE ROUTES BY TIME SLOT
        // -------------------------
        public DataTable GetAvailableRoutesByTimeSlot(DateTime date, int timeSlotId)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT DISTINCT
                        r.Id AS RouteId,
                        r.RouteName,
                        r.Direction
                    FROM BusAssignments ba
                    INNER JOIN Routes r ON r.Id = ba.RouteId
                    WHERE ba.Date = @Date
                      AND ba.TimeSlotId = @TimeSlotId
                    ORDER BY r.RouteName;";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Date", date.Date);
                cmd.Parameters.AddWithValue("@TimeSlotId", timeSlotId);

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
            }

            return table;
        }

        // -------------------------
        // GET DRIVER ASSIGNMENTS WITH DETAILS
        // -------------------------
        public DataTable GetByDriverWithDetails(
            int driverId,
            DateTime date)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT
                        ba.Id,
                        ba.Date,
                        b.BusName,
                        r.RouteName,
                        r.Direction,
                        CONVERT(varchar(5), ts.StartTime, 108) + ' - ' +
                        CONVERT(varchar(5), ts.EndTime, 108) AS TimeSlot
                    FROM BusAssignments ba
                    INNER JOIN Buses b
                        ON b.Id = ba.BusId
                    INNER JOIN Routes r
                        ON r.Id = ba.RouteId
                    INNER JOIN TimeSlots ts
                        ON ts.Id = ba.TimeSlotId
                    WHERE ba.DriverId = @DriverId
                      AND ba.Date = @Date
                    ORDER BY ts.StartTime;";

                using SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@DriverId",
                    driverId);

                cmd.Parameters.AddWithValue(
                    "@Date",
                    date.Date);

                con.Open();

                using SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}