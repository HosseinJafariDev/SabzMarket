using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Entities
{
    public class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
        public string? Source { get; set; }
        public string? Layer { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string? Curl { get; set; }
        public string? Route { get; set; }
    }
}
