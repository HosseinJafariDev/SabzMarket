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
    public class GetSellerByIdUseCase : IGetSellerByIdUseCase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        public GetSellerByIdUseCase(ISellerRepository sellerRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetSellerOutputDTO>> ExecuteAsync(long id, CancellationToken token)
        {
            try
            {
                var result = await _sellerRepository.SelectByIdAsync(id, token);
                if (result == null)
                {
                    return OperationResult<GetSellerOutputDTO>.Failed(OperationError.NotFound, Messages.NoSellerFoundWithId);
                }
                var sellerDTO = _mapper.Map<GetSellerOutputDTO>(result);
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
