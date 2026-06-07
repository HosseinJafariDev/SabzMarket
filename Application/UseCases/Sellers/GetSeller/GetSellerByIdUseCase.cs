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
    public class GetSellerByIdUseCase : IGetSellerByIdUseCase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        public GetSellerByIdUseCase(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetSellerOutputDTO>> ExecuteAsync(long id, CancellationToken token)
        {
            var result = await _sellerRepository.SelectByIdAsync(id, token);
            if (result == null)
            {
                throw new NotFoundException(Messages.NoSellerFoundWithId);
            }
            var sellerDTO = _mapper.Map<GetSellerOutputDTO>(result);

            return OperationResult<GetSellerOutputDTO>.Success(sellerDTO, OperationError.Success);
        }
    }
}
