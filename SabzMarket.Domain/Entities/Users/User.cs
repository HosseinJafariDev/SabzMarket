using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Chats;
using SabzMarket.Domain.Entities.Farmers;
using SabzMarket.Domain.Entities.Sellers;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Users;

public class User : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Phone { get; private set; }
    public string? Email { get; private set; }
    public string? UserName { get; private set; }
    public string? PasswordHash { get; private set; }

    public Seller? Seller { get; private init; }
    public Buyer? Farmer { get; private init; }
    public Chat? Chat { get; private init; }

    private User()
    {
    }

    public User(string firstName, string lastName, string phone)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException(UserDomainMessages.FirstnameRequired);
        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException(UserDomainMessages.LastnameRequired);
        if (string.IsNullOrWhiteSpace(phone))
            throw new DomainException(UserDomainMessages.PhoneRequired);

        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public void SetCredentials(string userName, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new DomainException(UserDomainMessages.UsernameRequired);
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException(UserDomainMessages.PasswordRequired);

        UserName = userName;
        PasswordHash = passwordHash;
    }

    public void Update(string firstName, string lastName, string userName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException(UserDomainMessages.FirstnameRequired);
        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException(UserDomainMessages.LastnameRequired);
        if (string.IsNullOrWhiteSpace(userName))
            throw new DomainException(UserDomainMessages.UsernameRequired);

        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }
}