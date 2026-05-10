using SabzMarket.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class ChatTable : BaseEntity
    {
        [Column(TypeName = "nvarchar(max)")]
        public string? Message { get; set; }
        public long FromUserId { get; set; }
        public UserTable? FromUser { get; set; }
        public long ToUserId { get; set; }
        public UserTable? ToUser { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsFile { get; set; }
    }
}
