using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class ChatTable
    {
      
            public long Id { get; set; }
            public string? Message { get; set; }

            public long FromUserId { get; set; }
            public UserTable? FromUser { get; set; }

            public long ToUserId { get; set; }
            public UserTable? ToUser { get; set; }
        

    }
}
