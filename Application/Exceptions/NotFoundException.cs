namespace SabzMarket.Application.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException(string message, Exception exception)
        : base(message, exception)
    {
    }
}