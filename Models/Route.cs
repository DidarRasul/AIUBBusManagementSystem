using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUBBusManagementSystem.Models
{
    internal class Route
    {
        public int Id { get; set; }

        public string RouteName { get; set; }

        public string Direction { get; set; }   // ToUniversity, FromUniversity
    }
}
