using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Models
{
    internal class TravelLog
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int AssignmentId { get; set; }

        public decimal Amount { get; set; }

        public bool IsPaid { get; set; }

        public bool PickupConfirmed { get; set; }

        public DateTime Date { get; set; }
    }
}
