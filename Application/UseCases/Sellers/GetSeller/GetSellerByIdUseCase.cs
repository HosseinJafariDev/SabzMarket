using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Constants.Seller;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Sellers;

namespace SabzMarket.Application.UseCases.Sellers.GetSeller;

public class GetSellerByIdUseCase(ISellerRepository sellerRepository) : IGetSellerByIdUseCase
{
    public async Task<GetSellerOutputDto> ExecuteAsync(long id, CancellationToken token)
    {
        var seller = await sellerRepository.GetWithUserAsync(id, token);
        if (seller == null)
        {
            throw new NotFoundException(CommonMessages.NotFoundWarning(SellerMessages.Seller));
        }

        return ToDto(seller);
    }

    private GetSellerOutputDto ToDto(Seller seller) => new(seller.Id, seller.UserId, seller.User!.UserName!,
        seller.User.FirstName, seller.User.LastName, seller.User.Email, seller.User.Phone, seller.Address,
        seller.ProfileImage, seller.WorkHistory);
}