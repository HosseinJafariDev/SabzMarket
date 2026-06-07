using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.GetSeller
{
    public class GetAllSellerByPhoneNumberUseCase : IGetAllSellerByPhoneNumberUseCase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        public GetAllSellerByPhoneNumberUseCase(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<GetSellerOutputDTO>>> ExecuteAsync(string phone, CancellationToken token)
        {
            var result = await _sellerRepository.SelectByPhoneNumberAsync(phone, token);
            if (result.Count == 0)
            {
                throw new NotFoundException(Messages.NoSellerFoundWithPhone);
            }
            var sellerDTO = _mapper.Map<List<GetSellerOutputDTO>>(result);

            return OperationResult<List<GetSellerOutputDTO>>.Success(sellerDTO, OperationError.Success);
        }
    }
}
