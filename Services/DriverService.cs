using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Repositories;
using AIUBBusManagementSystem.Utils;
using System;
using System.Data;

namespace AIUBBusManagementSystem.Services
{
    internal class DriverService
    {
        private readonly StudentPickupRepository _pickupRepo;
        private readonly TravelRepository _travelRepo;
        private readonly BusAssignmentRepository _assignmentRepo;

        public DriverService()
        {
            _pickupRepo = new StudentPickupRepository();
            _travelRepo = new TravelRepository();
            _assignmentRepo = new BusAssignmentRepository();
        }

        public DataTable GetMyAssignments(DateTime date)
        {
            if (SessionManager.CurrentUser == null)
                throw new Exception("No driver is currently logged in.");

            int driverId = SessionManager.CurrentUser.Id;
            return _assignmentRepo.GetByDriverWithDetails(driverId, date);
        }

        public DataTable GetLocationCountsForAssignment(int assignmentId, DateTime date)
        {
            if (SessionManager.CurrentUser == null)
                throw new Exception("No driver is currently logged in.");

            BusAssignment assignment = _assignmentRepo.GetById(assignmentId);

            if (assignment == null)
                throw new Exception("Assignment not found.");

            return _pickupRepo.GetLocationCountsForDriverAndTimeSlot(
                SessionManager.CurrentUser.Id,
                assignment.TimeSlotId,
                date);
        }

        public DataTable GetStudentsForLocationAndAssignment(
            int locationId,
            int assignmentId)
        {
            if (SessionManager.CurrentUser == null)
                throw new Exception("No driver is currently logged in.");

            BusAssignment assignment = _assignmentRepo.GetById(assignmentId);

            if (assignment == null)
                throw new Exception("Assignment not found.");

            return _pickupRepo.GetStudentsForLocationAndTimeSlot(
                locationId,
                assignment.TimeSlotId);
        }

        public void MarkStudentPicked(
            int studentId,
            int assignmentId,
            int locationId)
        {
            if (SessionManager.CurrentUser == null)
                throw new Exception("No driver is currently logged in.");

            BusAssignment assignment =
                _assignmentRepo.GetById(assignmentId);

            if (assignment == null)
                throw new Exception("Assignment not found.");

            decimal fare =
                _pickupRepo.GetFareByLocation(locationId);

            TravelLog travelLog = new TravelLog
            {
                StudentId = studentId,
                AssignmentId = assignmentId,
                Amount = fare,
                IsPaid = false,
                PickupConfirmed = true,
                Date = DateTime.Today
            };

            if (_travelRepo.Exists(
                studentId,
                assignmentId,
                DateTime.Today))
            {
                _travelRepo.MarkPickupConfirmed(
                    studentId,
                    assignmentId,
                    DateTime.Today);
            }
            else
            {
                _travelRepo.Create(travelLog);
            }
        }
    }
}