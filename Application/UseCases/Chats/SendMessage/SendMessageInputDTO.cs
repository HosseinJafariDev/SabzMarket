using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.SendMessage
{
    public class SendMessageInputDTO
    {
        public long Id { get; set; }
        public string? Message { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsFile { get; set; }
    }
}
