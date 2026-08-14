using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Users
{
    public class User
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public long Id { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public string? Email { get; private set; }
        public string? UserName { get; private set; }
        public string? PasswordHash { get; private set; }

        private User()
        {
        }

        public User(string firstName, string lastName, string phone)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException(UserMessages.FirstnameRequired);
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException(UserMessages.LastnameRequired);
            if (string.IsNullOrWhiteSpace(phone))
                throw new DomainException(UserMessages.PhoneRequired);

            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public void SetCredentials(string userName, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new DomainException(UserMessages.UsernameRequired);
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new DomainException(UserMessages.PasswordRequired);

            UserName = userName;
            PasswordHash = passwordHash;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}