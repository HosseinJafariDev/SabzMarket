using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Constants.Seller;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Sellers;

namespace SabzMarket.Application.UseCases.Sellers.GetSeller;

public class SearchSellersUseCase(ISellerRepository sellerRepository) : ISearchSellersUseCase
{
    public async Task<GetSellersPagedOutputDto> ExecuteAsync(SearchSellerFilterInputInputDto inputInputDto,
        CancellationToken token)
    {
        var result = await sellerRepository.GetPagedWithUserAsync(inputInputDto.Phone, inputInputDto.UserName,
            inputInputDto.PageNumber, inputInputDto.PageSize, token);

        if (result.TotalCount == 0)
        {
            throw new NotFoundException(CommonMessages.NotFoundWarning(SellerMessages.Seller));
        }

        return new GetSellersPagedOutputDto(ToDto(result.Items), result.TotalCount);
    }

    private static IReadOnlyList<GetSellerOutputDto> ToDto(IReadOnlyList<Seller> sellers) =>
        sellers.Select(x => new GetSellerOutputDto(x.Id, x.UserId, x.User!.UserName!, x.User.FirstName, x.User.LastName,
            x.User.Email, x.User.Phone, x.Address, x.ProfileImage, x.WorkHistory)).ToList();
}