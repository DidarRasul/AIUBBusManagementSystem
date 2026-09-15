using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Repositories;
using AIUBBusManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AIUBBusManagementSystem.Services
{
    internal class StudentService
    {
        private readonly UserRepository _userRepo;
        private readonly StudentProfileRepository _profileRepo;
        private readonly StudentPickupRepository _pickupRepo;
        private readonly BusAssignmentRepository _assignmentRepo;
        private readonly TravelRepository _travelRepo;

        public StudentService()
        {
            _userRepo = new UserRepository();
            _profileRepo = new StudentProfileRepository();
            _pickupRepo = new StudentPickupRepository();
            _assignmentRepo = new BusAssignmentRepository();
            _travelRepo = new TravelRepository();
        }

        // ==================================================
        // STUDENT REGISTRATION
        // ==================================================

        public void RegisterStudent(
            string name,
            string username,
            string password,
            string studentId,
            string department,
            string email)
        {
            User user = new User
            {
                Name = name,
                Username = username,
                Password = password,
                Role = "Student",
                Status = "Pending"
            };

            _userRepo.Create(user);

            User createdUser =
                _userRepo.GetByUsernameAndPassword(username, password);

            if (createdUser == null)
            {
                throw new Exception("Student account could not be created.");
            }

            StudentProfile profile = new StudentProfile
            {
                UserId = createdUser.Id,
                StudentId = studentId,
                Department = department,
                Email = email
            };

            _profileRepo.Create(profile);
        }

        // ==================================================
        // PICKUP SELECTION
        // ==================================================

        public void SelectPickupLocation(int timeSlotId, int locationId)
        {
            if (SessionManager.CurrentUser == null)
            {
                throw new Exception("No student is currently logged in.");
            }

            int studentId = SessionManager.CurrentUser.Id;

            StudentPickupSelection selection = new StudentPickupSelection
            {
                StudentId = studentId,
                LocationId = locationId,
                TimeSlotId = timeSlotId
            };

            _pickupRepo.Create(selection);
        }

        public void SavePickupSelection(int locationId, int timeSlotId)
        {
            if (SessionManager.CurrentUser == null)
            {
                throw new Exception("No student is currently logged in.");
            }

            int studentId = SessionManager.CurrentUser.Id;

            StudentPickupSelection selection = new StudentPickupSelection
            {
                StudentId = studentId,
                LocationId = locationId,
                TimeSlotId = timeSlotId
            };

            _pickupRepo.Create(selection);
        }

        public List<StudentPickupSelection> GetMyPickupSelections()
        {
            if (SessionManager.CurrentUser == null)
            {
                throw new Exception("No student is currently logged in.");
            }

            int studentId = SessionManager.CurrentUser.Id;

            return _pickupRepo.GetByStudent(studentId);
        }

        // ==================================================
        // AVAILABLE BUS / ROUTES
        // ==================================================

        public List<BusAssignment> GetAvailableBuses()
        {
            return _assignmentRepo.GetByDate(DateTime.Today);
        }

        public DataTable GetAvailableRoutesForTimeSlotToday(int timeSlotId)
        {
            return _assignmentRepo.GetAvailableRoutesByTimeSlot(
                DateTime.Today,
                timeSlotId
            );
        }

        // ==================================================
        // FEE PAYMENT
        // ==================================================

        public List<TravelLog> GetMyDueFees()
        {
            if (SessionManager.CurrentUser == null)
            {
                throw new Exception("No student is currently logged in.");
            }

            int studentId = SessionManager.CurrentUser.Id;

            return _travelRepo.GetDueByStudent(studentId);
        }

        public DataTable GetMyDueFeesTable()
        {
            if (SessionManager.CurrentUser == null)
            {
                throw new Exception("No student is currently logged in.");
            }

            int studentId = SessionManager.CurrentUser.Id;

            return _travelRepo.GetDueFeesTableByStudent(studentId);
        }

        public decimal GetMyTotalDueAmount()
        {
            return GetMyDueFees().Sum(t => t.Amount);
        }

        public bool PayFees(decimal inputAmount)
        {
            List<TravelLog> dueLogs = GetMyDueFees();

            decimal totalDue = dueLogs.Sum(t => t.Amount);

            // Student must pay the exact due amount
            if (inputAmount != totalDue)
            {
                return false;
            }

            foreach (TravelLog log in dueLogs)
            {
                _travelRepo.MarkPaid(log.Id);
            }

            return true;
        }

        // ==================================================
        // STUDENT PROFILE
        // ==================================================

        public StudentProfile GetMyProfile()
        {
            if (SessionManager.CurrentUser == null)
            {
                throw new Exception("No student is currently logged in.");
            }

            int studentId = SessionManager.CurrentUser.Id;

            return _profileRepo.GetByUserId(studentId);
        }

        public void UpdateProfile(
            string studentId,
            string department,
            string email)
        {
            if (SessionManager.CurrentUser == null)
            {
                throw new Exception("No student is currently logged in.");
            }

            int userId = SessionManager.CurrentUser.Id;

            StudentProfile profile = new StudentProfile
            {
                UserId = userId,
                StudentId = studentId,
                Department = department,
                Email = email
            };

            _profileRepo.Update(profile);
        }
    }
}