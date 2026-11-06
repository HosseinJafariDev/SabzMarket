using SabzMarket.Application.Common;
using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.User;
using UserMessages = SabzMarket.Application.Constants.User.UserMessages;

namespace SabzMarket.Application.UseCases.Users.GetUser;

public class GetUserByUserNameUseCase(IUserRepository userRepository) : IGetUserByUserNameUseCase
{
    public async Task<GetUserByUserNameOutputDto> ExecuteAsync(string username,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new BadRequestException(Messages.UserNameMinLength);

        var user = await userRepository.GetByUserNameAsync(username, token);
        if (user is null)
        {
            throw new NotFoundException(CommonMessages.NotFoundWarning(UserMessages.User));
        }

        return ToDto(user);
    }

    private static GetUserByUserNameOutputDto ToDto(User user) => new(user.Id, user.UserName, user.FirstName,
        user.LastName, user.Email, user.Phone);
}