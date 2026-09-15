using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace AIUBBusManagementSystem.Repositories
{
    internal class RouteLocationRepository
    {
        // -------------------------
        // ADD LOCATION TO ROUTE
        // -------------------------
        public void Create(RouteLocation location)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO RouteLocations (RouteId, LocationName, Fare)
                    VALUES (@RouteId, @LocationName, @Fare)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@RouteId", location.RouteId);
                cmd.Parameters.AddWithValue("@LocationName", location.LocationName);
                cmd.Parameters.AddWithValue("@Fare", location.Fare);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // GET LOCATIONS BY ROUTE
        // -------------------------
        public List<RouteLocation> GetByRouteId(int routeId)
        {
            List<RouteLocation> locations = new List<RouteLocation>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM RouteLocations
                    WHERE RouteId = @RouteId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RouteId", routeId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    locations.Add(MapLocation(reader));
                }
            }

            return locations;
        }

        // -------------------------
        // GET ALL LOCATIONS
        // -------------------------
        public List<RouteLocation> GetAll()
        {
            List<RouteLocation> locations = new List<RouteLocation>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM RouteLocations";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    locations.Add(MapLocation(reader));
                }
            }

            return locations;
        }

        // -------------------------
        // PRIVATE MAPPER
        // -------------------------
        private RouteLocation MapLocation(SqlDataReader reader)
        {
            return new RouteLocation
            {
                Id = Convert.ToInt32(reader["Id"]),
                RouteId = Convert.ToInt32(reader["RouteId"]),
                LocationName = reader["LocationName"].ToString(),
                Fare = Convert.ToDecimal(reader["Fare"])
            };
        }
    }
}