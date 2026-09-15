using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Repositories;
using AIUBBusManagementSystem.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace AIUBBusManagementSystem.Services
{
    internal class AdminService
    {
        private readonly UserRepository _userRepo;
        private readonly StudentProfileRepository _studentProfileRepo;
        private readonly DriverProfileRepository _driverProfileRepo;
        private readonly RouteRepository _routeRepo;
        private readonly RouteLocationRepository _locationRepo;
        private readonly BusAssignmentRepository _assignmentRepo;
        private readonly TravelRepository _travelRepo;

        public AdminService()
        {
            _userRepo = new UserRepository();
            _studentProfileRepo = new StudentProfileRepository();
            _driverProfileRepo = new DriverProfileRepository();
            _routeRepo = new RouteRepository();
            _locationRepo = new RouteLocationRepository();
            _assignmentRepo = new BusAssignmentRepository();
            _travelRepo = new TravelRepository();
        }

        // =====================================================
        // DRIVER MANAGEMENT
        // =====================================================

        public void CreateDriver(
            string name,
            string username,
            string password,
            string licenseNo,
            string phone)
        {
            User driver = new User
            {
                Name = name,
                Username = username,
                Password = password,
                Role = "Driver",
                Status = "Active"
            };

            _userRepo.Create(driver);

            User createdDriver =
                _userRepo.GetByUsernameAndPassword(
                    username,
                    password);

            if (createdDriver == null)
            {
                throw new Exception(
                    "Driver account could not be created.");
            }

            DriverProfile profile = new DriverProfile
            {
                UserId = createdDriver.Id,
                LicenseNo = licenseNo,
                Phone = phone
            };

            _driverProfileRepo.Create(profile);
        }

        public void RemoveDriver(int driverUserId)
        {
            _userRepo.Delete(driverUserId);
        }

        public DataTable GetAllDrivers()
        {
            return _userRepo.GetAllDriversWithDetails();
        }

        public DataTable GetActiveDriversForAssignment()
        {
            return _userRepo.GetActiveDriversForAssignment();
        }

        public void ActivateDriver(int driverUserId)
        {
            _userRepo.UpdateStatus(
                driverUserId,
                "Active");
        }

        public void BlockDriver(int driverUserId)
        {
            _userRepo.UpdateStatus(
                driverUserId,
                "Blocked");
        }

        // =====================================================
        // STUDENT MANAGEMENT
        // =====================================================

        public DataTable GetAllStudents()
        {
            return _userRepo.GetAllStudentsWithDetails();
        }

        public DataTable GetAllStudents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllStudents();
            }

            return _userRepo.SearchStudentsWithDetails(
                keyword.Trim());
        }

        public void ActivateStudent(int studentUserId)
        {
            _userRepo.UpdateStatus(
                studentUserId,
                "Active");
        }

        public void BlockStudent(int studentUserId)
        {
            _userRepo.UpdateStatus(
                studentUserId,
                "Blocked");
        }

        // =====================================================
        // ADMIN MANAGEMENT
        // =====================================================

        public DataTable GetAllAdmins()
        {
            return _userRepo.GetAllAdmins();
        }

        public void ApproveAdmin(int adminUserId)
        {
            _userRepo.ApproveAdmin(adminUserId);
        }

        public void BlockAdmin(int adminUserId)
        {
            _userRepo.BlockAdmin(adminUserId);
        }

        // =====================================================
        // ROUTE & LOCATION MANAGEMENT
        // =====================================================

        public int CreateRoute(
            string routeName,
            string direction)
        {
            // UI direction -> Database accepted direction
            if (direction == "To University")
            {
                direction = "AIUB to Dhaka";
            }
            else if (direction == "From University")
            {
                direction = "Dhaka to AIUB";
            }

            Route route = new Route
            {
                RouteName = routeName,
                Direction = direction
            };

            return _routeRepo.Create(route);
        }

        public void AddLocationToRoute(
            int routeId,
            string locationName,
            decimal fare)
        {
            RouteLocation location =
                new RouteLocation
                {
                    RouteId = routeId,
                    LocationName = locationName,
                    Fare = fare
                };

            _locationRepo.Create(location);
        }

        public List<Route> GetAllRoutes()
        {
            return _routeRepo.GetAll();
        }

        public List<RouteLocation> GetLocationsByRoute(
            int routeId)
        {
            return _locationRepo.GetByRouteId(routeId);
        }

        // =====================================================
        // BUS ASSIGNMENT
        // =====================================================

        public void AssignBus(
            int routeId,
            int driverId,
            int busId,
            int timeSlotId,
            DateTime date)
        {
            BusAssignment assignment =
                new BusAssignment
                {
                    RouteId = routeId,
                    DriverId = driverId,
                    BusId = busId,
                    TimeSlotId = timeSlotId,
                    Date = date.Date
                };

            _assignmentRepo.Create(assignment);
        }

        public DataTable GetAllBuses()
        {
            DataTable table = new DataTable();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT Id, BusName
                    FROM Buses
                    WHERE Status = 'Active'
                    ORDER BY BusName";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
            }

            return table;
        }

        public List<TimeSlot> GetAllTimeSlots()
        {
            TimeSlotRepository repo =
                new TimeSlotRepository();

            return repo.GetAll();
        }

        public List<BusAssignment> GetAssignmentsByDate(
            DateTime date)
        {
            return _assignmentRepo.GetByDate(date);
        }

        public DataTable GetAssignmentsByDateWithDetails(
            DateTime date)
        {
            return _assignmentRepo.GetByDateWithDetails(date);
        }

        // =====================================================
        // REPORTS
        // =====================================================

        public decimal GetTotalCollectedFees()
        {
            return _travelRepo.GetTotalCollected();
        }

        public DataTable GetReport()
        {
            return _travelRepo.GetReport();
        }
    }
}