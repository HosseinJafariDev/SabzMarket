using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Users;

namespace SabzMarket.Domain.Entities.Chats
{
    public class Chat : BaseEntity
    {
        public string? Message { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsFile { get; set; }

        public User? FromUser { get; private init; }
        public User? ToUser { get; private init; }
    }
}