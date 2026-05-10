using SabzMarket.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class ErrorTable: BaseEntity<int>
    {
        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string? Source { get; set; }
        public string? Layer { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Curl { get; set; }
        public string? Route { get; set; }
    }
}
