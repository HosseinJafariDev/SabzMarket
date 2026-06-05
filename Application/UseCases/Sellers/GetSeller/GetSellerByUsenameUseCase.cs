using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
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
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        public GetSellerByUsenameUseCase(ISellerRepository sellerRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetSellerOutputDTO>> ExecuteAsync(string username, CancellationToken token)
        {
            try
            {
                var seller = await _sellerRepository.SelectByUsernameAsync(username, token);
                if (seller == null)
                {
                    return OperationResult<GetSellerOutputDTO>.Failed(OperationError.NotFound, Messages.NoSellerFoundWhithUsename);
                }
                var sellerDTO = _mapper.Map<GetSellerOutputDTO>(seller);
                return OperationResult<GetSellerOutputDTO>.Success(sellerDTO, OperationError.Success);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<GetSellerOutputDTO>.Failed(OperationError.ServerError, errorResult.ErrorMessage());
            }

        }
    }
}

