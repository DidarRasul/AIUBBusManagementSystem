using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Utils;
using AIUBBusManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Repositories
{
    internal class RouteRepository
    {
        // -------------------------
        // CREATE ROUTE
        // -------------------------
        public int Create(Route route)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO Routes (RouteName, Direction)
                    OUTPUT INSERTED.Id
                    VALUES (@RouteName, @Direction)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RouteName", route.RouteName);
                cmd.Parameters.AddWithValue("@Direction", route.Direction);

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // -------------------------
        // GET ALL ROUTES
        // -------------------------

        public DataTable GetAllRoutesByDriverId(int driverId)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
            SELECT
                r.Id AS RouteId,
                r.RouteName,
                r.Direction,
                CONVERT(varchar(5), ts.StartTime, 108) + ' - ' + CONVERT(varchar(5), ts.EndTime, 108) AS Time,
                ba.Date
            FROM BusAssignments ba
            INNER JOIN Routes r ON r.Id = ba.RouteId
            INNER JOIN TimeSlots ts ON ts.Id = ba.TimeSlotId
            WHERE ba.DriverId = @DriverId
            ORDER BY ba.Date DESC, ts.StartTime;";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DriverId", driverId);

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
            }

            return table;
        }

        public List<Route> GetAll()
        {
            List<Route> routes = new List<Route>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM Routes";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    routes.Add(MapRoute(reader));
                }
            }

            return routes;
        }

        // -------------------------
        // GET ROUTE BY ID
        // -------------------------


        public Route GetById(int id)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM Routes WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapRoute(reader);
                }

                return null;
            }
        }

        // -------------------------
        // PRIVATE MAPPER
        // -------------------------
        private Route MapRoute(SqlDataReader reader)
        {
            object routeNameObj = reader["RouteName"];
            object directionObj = reader["Direction"];

            string? routeName = routeNameObj == DBNull.Value ? null : routeNameObj?.ToString();
            string? direction = directionObj == DBNull.Value ? null : directionObj?.ToString();

            if (string.IsNullOrWhiteSpace(routeName))
            {
                throw new InvalidOperationException("Routes.RouteName is NULL/empty in the database.");
            }

            if (string.IsNullOrWhiteSpace(direction))
            {
                throw new InvalidOperationException("Routes.Direction is NULL/empty in the database.");
            }

            return new Route
            {
                Id = Convert.ToInt32(reader["Id"]),
                RouteName = routeName,
                Direction = direction
            };
        }
    }
}
