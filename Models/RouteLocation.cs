using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Models
{
    internal class RouteLocation
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public string LocationName { get; set; }

        public decimal Fare { get; set; }
    }
}