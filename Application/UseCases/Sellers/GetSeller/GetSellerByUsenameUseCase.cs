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
    public class GetSellerByUsenameUseCase : IGetSellerByUsenameUseCase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        public GetSellerByUsenameUseCase(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetSellerOutputDTO>> ExecuteAsync(string username, CancellationToken token)
        {
            var seller = await _sellerRepository.SelectByUsernameAsync(username, token);
            if (seller == null)
            {
                throw new NotFoundException(Messages.NoSellerFoundWhithUsename);
            }
            var sellerDTO = _mapper.Map<GetSellerOutputDTO>(seller);

            return OperationResult<GetSellerOutputDTO>.Success(sellerDTO, OperationError.Success);
        }
    }
}

