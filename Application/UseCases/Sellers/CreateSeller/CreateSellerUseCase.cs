using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Common.Enums;
using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Constants.User;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities.Sellers;

namespace SabzMarket.Application.UseCases.Sellers.CreateSeller;

public class CreateSellerUseCase(
    ISellerRepository sellerRepository,
    IFileStorageService fileStorageService,
    IUnitOfWork unitOfWork,
    IUserRepository userRepository)
    : ICreateSellerUseCase
{
    public async Task ExecuteAsync(CreateSellerInputDto inputDto, string fileName, Stream stream,
        CancellationToken token)
    {
        var user = await userRepository.GetByUserNameAsync(inputDto.Username, token);

        if (user is null)
            throw new NotFoundException(CommonMessages.NotFoundWarning(UserMessages.User));

        var seller = new Seller(user.Id, inputDto.Address, inputDto.WorkHistory);

        var imageUrl =
            await fileStorageService.SaveAsync(stream, fileName, FileFolder.SellerProfile, seller.Id, token);

        sellerRepository.Add(seller);
        await unitOfWork.SaveChangesAsync(token);

        seller.UpdateProfileImage(imageUrl);

        sellerRepository.Update(seller);

        await unitOfWork.SaveChangesAsync(token);
    }
}