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
    internal class TravelRepository
    {
        // -------------------------
        // CREATE TRAVEL LOG
        // (On pickup confirmation)
        // -------------------------
        public void Create(TravelLog log)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO TravelLogs
                    (StudentId, AssignmentId, Amount, IsPaid, PickupConfirmed, Date)
                    VALUES (@StudentId, @AssignmentId, @Amount, @IsPaid, @PickupConfirmed, @Date)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", log.StudentId);
                cmd.Parameters.AddWithValue("@AssignmentId", log.AssignmentId);
                cmd.Parameters.AddWithValue("@Amount", log.Amount);
                cmd.Parameters.AddWithValue("@IsPaid", log.IsPaid);
                cmd.Parameters.AddWithValue("@PickupConfirmed", log.PickupConfirmed);
                cmd.Parameters.AddWithValue("@Date", log.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // GET DUE FEES BY STUDENT
        // -------------------------
        public List<TravelLog> GetDueByStudent(int studentId)
        {
            List<TravelLog> logs = new List<TravelLog>();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT *
                    FROM TravelLogs
                    WHERE StudentId = @StudentId
                      AND IsPaid = 0";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    logs.Add(MapLog(reader));
                }
            }

            return logs;
        }

        // -------------------------
        // MARK PAYMENT
        // -------------------------
        public void MarkPaid(int travelLogId)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    UPDATE TravelLogs
                    SET IsPaid = 1
                    WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", travelLogId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------
        // GET TOTAL COLLECTED (ADMIN)
        // -------------------------
        public decimal GetTotalCollected()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT ISNULL(SUM(Amount), 0)
                    FROM TravelLogs
                    WHERE IsPaid = 1";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // -------------------------
        // GET REPORT
        // -------------------------
        public DataTable GetReport()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT
                        tl.Id,
                        tl.Date,
                        u.Name AS StudentName,
                        r.RouteName,
                        CONVERT(varchar(5), ts.StartTime, 108) + ' - ' + CONVERT(varchar(5), ts.EndTime, 108) AS TimeSlot,
                        tl.Amount,
                        tl.IsPaid,
                        tl.PickupConfirmed
                    FROM TravelLogs tl
                    INNER JOIN Users u ON u.Id = tl.StudentId
                    INNER JOIN BusAssignments ba ON ba.Id = tl.AssignmentId
                    INNER JOIN Routes r ON r.Id = ba.RouteId
                    INNER JOIN TimeSlots ts ON ts.Id = ba.TimeSlotId
                    ORDER BY tl.Date DESC, tl.Id DESC;";

                using SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // -------------------------
        // PRIVATE MAPPER
        // -------------------------
        private TravelLog MapLog(SqlDataReader reader)
        {
            return new TravelLog
            {
                Id = Convert.ToInt32(reader["Id"]),
                StudentId = Convert.ToInt32(reader["StudentId"]),
                AssignmentId = Convert.ToInt32(reader["AssignmentId"]),
                Amount = Convert.ToDecimal(reader["Amount"]),
                IsPaid = Convert.ToBoolean(reader["IsPaid"]),
                PickupConfirmed = Convert.ToBoolean(reader["PickupConfirmed"]),
                Date = Convert.ToDateTime(reader["Date"])
            };
        }


        public void ConfirmPickupForToday(int studentId)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                // If a travel log exists for today, update it; otherwise create a minimal one.
                const string existsQuery = @"
                    SELECT TOP 1 Id
                    FROM TravelLogs
                    WHERE StudentId = @StudentId
                      AND Date = @Date;";

                using SqlCommand existsCmd = new SqlCommand(existsQuery, con);
                existsCmd.Parameters.AddWithValue("@StudentId", studentId);
                existsCmd.Parameters.AddWithValue("@Date", DateTime.Today);

                object? idObj = existsCmd.ExecuteScalar();

                if (idObj != null && idObj != DBNull.Value)
                {
                    const string updateQuery = @"
                        UPDATE TravelLogs
                        SET PickupConfirmed = 1
                        WHERE Id = @Id;";

                    using SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(idObj));
                    updateCmd.ExecuteNonQuery();
                    return;
                }

                const string insertQuery = @"
                    INSERT INTO TravelLogs (StudentId, AssignmentId, Amount, PickupConfirmed, IsPaid, Date)
                    VALUES (@StudentId, NULL, 10, 1, 0, @Date);";

                using SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@StudentId", studentId);
                insertCmd.Parameters.AddWithValue("@Date", DateTime.Today);
                insertCmd.ExecuteNonQuery();
            }
        }

        public bool Exists(int studentId, int assignmentId, DateTime date)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT COUNT(1)
                    FROM TravelLogs
                    WHERE StudentId = @StudentId
                      AND AssignmentId = @AssignmentId
                      AND Date = @Date;";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@AssignmentId", assignmentId);
                cmd.Parameters.AddWithValue("@Date", date.Date);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public void MarkPickupConfirmed(int studentId, int assignmentId, DateTime date)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    UPDATE TravelLogs
                    SET PickupConfirmed = 1
                    WHERE StudentId = @StudentId
                      AND AssignmentId = @AssignmentId
                      AND Date = @Date;";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@AssignmentId", assignmentId);
                cmd.Parameters.AddWithValue("@Date", date.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetDueFeesTableByStudent(int studentId)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                const string query = @"
                    SELECT
                        Date,
                        Amount,
                        CASE WHEN IsPaid = 1 THEN 'Paid' ELSE 'Due' END AS Status
                    FROM TravelLogs
                    WHERE StudentId = @StudentId
                      AND IsPaid = 0
                    ORDER BY Date DESC, Id DESC;";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                con.Open();

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
