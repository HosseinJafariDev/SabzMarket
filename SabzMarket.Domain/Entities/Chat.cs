using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Entities
{
    public class Chat
    {
            public long Id { get; set; }
            public string? Message { get; set; }
            public long FromUserId { get; set; }
            public long ToUserId { get; set; }
    }
}
