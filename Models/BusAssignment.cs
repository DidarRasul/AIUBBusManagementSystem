using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Models
{
    internal class BusAssignment
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int DriverId { get; set; }

        public int BusId { get; set; }

        public int TimeSlotId { get; set; }

        public DateTime Date { get; set; }
    }
}