using System;
using System.Collections.Generic;
using System.Text;

namespace SabzMarket.Share.Models
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
