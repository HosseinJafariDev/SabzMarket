using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Chat;

public class Chat : BaseEntity
{
    public string Message { get; private set; }
    public long SenderId { get; private set; }
    public long ReceiverId { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsRead { get; private set; }
    public DateTime SentAt { get; private set; }
    public bool IsFile { get; private set; }

    public User.User? FromUser { get; private init; }
    public User.User? ToUser { get; private init; }

    private Chat()
    {
    }

    public Chat(string message, long fromUserId, long toUserId, bool isFile)
    {
        if (string.IsNullOrWhiteSpace(message))
            throw new DomainException(ChatDomainMessages.MessageIsRequired);

        if (fromUserId <= 0)
            throw new DomainException(ChatDomainMessages.SenderIdRequired);

        if (toUserId <= 0)
            throw new DomainException(ChatDomainMessages.ReceiverIdRequired);

        Message = message;
        SenderId = fromUserId;
        ReceiverId = toUserId;
        IsFile = isFile;
        SentAt = DateTime.UtcNow;
    }

    public void Delete() => IsDeleted = true;
    public void MarkAsRead() => IsRead = true;
}