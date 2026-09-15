using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Models
{
    internal class StudentPickupSelection
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int LocationId { get; set; }

        public int TimeSlotId { get; set; }
    }
}
