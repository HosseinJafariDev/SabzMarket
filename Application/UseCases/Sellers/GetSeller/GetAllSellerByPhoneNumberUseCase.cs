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
    public class GetAllSellerByPhoneNumberUseCase : IGetAllSellerByPhoneNumberUseCase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        public GetAllSellerByPhoneNumberUseCase(ISellerRepository sellerRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<GetSellerOutputDTO>>> ExecuteAsync(string phone, CancellationToken token)
        {
            try
            {
                var result = await _sellerRepository.SelectByPhoneNumberAsync(phone, token);
                if (result.Count == 0)
                {
                    return OperationResult<List<GetSellerOutputDTO>>.Failed(OperationError.NotFound, Messages.NoSellerFoundWithPhone);
                }
                var sellerDTO = _mapper.Map<List<GetSellerOutputDTO>>(result);
                return OperationResult<List<GetSellerOutputDTO>>.Success(sellerDTO, OperationError.Success);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<List<GetSellerOutputDTO>>.Failed(OperationError.ServerError, errorResult.ErrorMessage());
            }
        }
    }
}
