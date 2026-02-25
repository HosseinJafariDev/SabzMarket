using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Common
{
    public class ErrorLogDTO
    {
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public string? Source { get; set; }
        public string? Layer { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Curl { get; set; }
        public string? Route { get; set; }
    }
}
