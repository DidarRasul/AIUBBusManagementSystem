using AIUBBusManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using AIUBBusManagementSystem.Utils;

namespace AIUBBusManagementSystem.Repositories
{
    internal class StudentPickupRepository
    {
        // ADD PICKUP SELECTION
        public void Create(StudentPickupSelection selection)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                using (SqlTransaction transaction =
                    con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        const string assignmentQuery = @"
                            SELECT TOP 1
                                ba.Id AS AssignmentId,
                                ba.BusId,
                                ba.RouteId,
                                ts.StartTime
                            FROM RouteLocations rl
                            INNER JOIN BusAssignments ba
                                ON ba.RouteId = rl.RouteId
                               AND ba.TimeSlotId = @TimeSlotId
                               AND ba.Date = @Date
                            INNER JOIN TimeSlots ts
                                ON ts.Id = ba.TimeSlotId
                            WHERE rl.Id = @LocationId;";

                        int assignmentId = 0;
                        int busId = 0;
                        int routeId = 0;
                        TimeSpan departureTime = TimeSpan.Zero;

                        using (SqlCommand cmd =
                            new SqlCommand(assignmentQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@LocationId",
                                selection.LocationId);

                            cmd.Parameters.AddWithValue(
                                "@TimeSlotId",
                                selection.TimeSlotId);

                            cmd.Parameters.AddWithValue(
                                "@Date",
                                DateTime.Today);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new Exception(
                                        "No bus is assigned for this route and time slot today.");
                                }

                                assignmentId =
                                    Convert.ToInt32(reader["AssignmentId"]);

                                busId =
                                    Convert.ToInt32(reader["BusId"]);

                                routeId =
                                    Convert.ToInt32(reader["RouteId"]);

                                departureTime =
                                    (TimeSpan)reader["StartTime"];
                            }
                        }

                        DateTime departureDateTime =
                            DateTime.Today.Add(departureTime);

                        DateTime cutoffTime =
                            departureDateTime.AddMinutes(-10);

                      // if (DateTime.Now >= cutoffTime)
                       // {
                            //throw new Exception(
                               // "Pickup request is closed. No new request can be made within 10 minutes of departure.");
                       // }

                        const string countQuery = @"
                            SELECT COUNT(*)
                            FROM StudentPickupSelections sps
                            INNER JOIN RouteLocations rl
                                ON rl.Id = sps.LocationId
                            INNER JOIN BusAssignments ba
                                ON ba.RouteId = rl.RouteId
                               AND ba.TimeSlotId = sps.TimeSlotId
                               AND ba.Date = @Date
                            WHERE ba.Id = @AssignmentId
                              AND sps.StudentId <> @StudentId;";

                        int studentCount = 0;

                        using (SqlCommand countCmd =
                            new SqlCommand(countQuery, con, transaction))
                        {
                            countCmd.Parameters.AddWithValue(
                                "@AssignmentId",
                                assignmentId);

                            countCmd.Parameters.AddWithValue(
                                "@StudentId",
                                selection.StudentId);

                            countCmd.Parameters.AddWithValue(
                                "@Date",
                                DateTime.Today);

                            studentCount =
                                Convert.ToInt32(countCmd.ExecuteScalar());
                        }

                        if (studentCount >= 40)
                        {
                            throw new Exception(
                                "This bus is full. Maximum capacity is 40 students.");
                        }

                        const string deleteQuery = @"
                            DELETE FROM StudentPickupSelections
                            WHERE StudentId = @StudentId
                              AND TimeSlotId = @TimeSlotId;";

                        using (SqlCommand deleteCmd =
                            new SqlCommand(deleteQuery, con, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue(
                                "@StudentId",
                                selection.StudentId);

                            deleteCmd.Parameters.AddWithValue(
                                "@TimeSlotId",
                                selection.TimeSlotId);

                            deleteCmd.ExecuteNonQuery();
                        }

                        const string insertQuery = @"
                            INSERT INTO StudentPickupSelections
                            (StudentId, LocationId, TimeSlotId)
                            VALUES
                            (@StudentId, @LocationId, @TimeSlotId);";

                        using (SqlCommand insertCmd =
                            new SqlCommand(insertQuery, con, transaction))
                        {
                            insertCmd.Parameters.AddWithValue(
                                "@StudentId",
                                selection.StudentId);

                            insertCmd.Parameters.AddWithValue(
                                "@LocationId",
                                selection.LocationId);

                            insertCmd.Parameters.AddWithValue(
                                "@TimeSlotId",
                                selection.TimeSlotId);

                            insertCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // GET PICKUPS BY STUDENT
        public List<StudentPickupSelection> GetByStudent(int studentId)
        {
            List<StudentPickupSelection> selections =
                new List<StudentPickupSelection>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM StudentPickupSelections
                    WHERE StudentId = @StudentId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    selections.Add(MapSelection(reader));
                }
            }

            return selections;
        }

        // GET PICKUPS BY TIME SLOT
        // (Used by Driver)
        public List<StudentPickupSelection> GetByTimeSlot(int timeSlotId)
        {
            List<StudentPickupSelection> selections =
                new List<StudentPickupSelection>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM StudentPickupSelections
                    WHERE TimeSlotId = @TimeSlotId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TimeSlotId", timeSlotId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    selections.Add(MapSelection(reader));
                }
            }

            return selections;
        }

        // PRIVATE MAPPER
        private StudentPickupSelection MapSelection(SqlDataReader reader)
        {
            return new StudentPickupSelection
            {
                Id = Convert.ToInt32(reader["Id"]),
                StudentId = Convert.ToInt32(reader["StudentId"]),
                LocationId = Convert.ToInt32(reader["LocationId"]),
                TimeSlotId = Convert.ToInt32(reader["TimeSlotId"])
            };
        }

        public DataTable GetLocationCountsForDriverAndTimeSlot(
            int driverId,
            int timeSlotId,
            DateTime date)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT
                        rl.Id AS LocationId,
                        rl.LocationName,
                        COUNT(sps.Id) AS StudentCount
                    FROM BusAssignments ba
                    INNER JOIN RouteLocations rl
                        ON rl.RouteId = ba.RouteId
                    LEFT JOIN StudentPickupSelections sps
                        ON sps.LocationId = rl.Id
                       AND sps.TimeSlotId = ba.TimeSlotId
                    WHERE ba.DriverId = @DriverId
                      AND ba.TimeSlotId = @TimeSlotId
                      AND ba.Date = @Date
                    GROUP BY rl.Id, rl.LocationName
                    ORDER BY rl.LocationName;";

                using SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@DriverId",
                    driverId);

                cmd.Parameters.AddWithValue(
                    "@TimeSlotId",
                    timeSlotId);

                cmd.Parameters.AddWithValue(
                    "@Date",
                    date.Date);

                using SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                da.Fill(table);
            }

            return table;
        }

        public DataTable GetStudentsForLocationAndTimeSlot(
            int locationId,
            int timeSlotId)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT
                        u.Name AS StudentName,
                        sp.StudentId,
                        CASE
                            WHEN tl.PickupConfirmed = 1
                            THEN 'Picked'
                            ELSE 'Not Picked'
                        END AS PickupStatus,
                        sps.StudentId AS StudentUserId,
                        tl.Id AS TravelLogId
                    FROM StudentPickupSelections sps
                    INNER JOIN Users u
                        ON u.Id = sps.StudentId
                    INNER JOIN StudentProfiles sp
                        ON sp.UserId = u.Id
                    LEFT JOIN TravelLogs tl
                        ON tl.StudentId = sps.StudentId
                       AND tl.Date = CAST(GETDATE() AS date)
                    WHERE sps.LocationId = @LocationId
                      AND sps.TimeSlotId = @TimeSlotId
                    ORDER BY u.Name;";

                using SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@LocationId",
                    locationId);

                cmd.Parameters.AddWithValue(
                    "@TimeSlotId",
                    timeSlotId);

                using SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                da.Fill(table);
            }

            return table;
        }

        public void DeleteByStudentAndTimeSlot(
            int studentId,
            int timeSlotId)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    DELETE FROM StudentPickupSelections
                    WHERE StudentId = @StudentId
                      AND TimeSlotId = @TimeSlotId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@StudentId",
                    studentId);

                cmd.Parameters.AddWithValue(
                    "@TimeSlotId",
                    timeSlotId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public decimal GetFareByLocation(int locationId)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT Fare
                    FROM RouteLocations
                    WHERE Id = @LocationId;";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@LocationId",
                        locationId);

                    con.Open();

                    object result = cmd.ExecuteScalar();

                    if (result == null ||
                        result == DBNull.Value)
                    {
                        throw new Exception(
                            "Fare not found for this pickup location.");
                    }

                    return Convert.ToDecimal(result);
                }
            }
        }
    }
}