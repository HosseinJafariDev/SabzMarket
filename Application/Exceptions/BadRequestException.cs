namespace SabzMarket.Application.Exceptions;

public class BadRequestException : AppException
{
    public BadRequestException(string message)
        : base(message)
    {
    }

    public BadRequestException(string message, Exception exception)
        : base(message, exception)
    {
    }
}