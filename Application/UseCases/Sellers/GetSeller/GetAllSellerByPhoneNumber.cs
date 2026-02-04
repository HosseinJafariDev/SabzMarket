using Application.Interfaces.Services;
using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.GetSeller
{
    public class GetAllSellerByPhoneNumber : IGetAllSellerByPhoneNumber
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IErrorService _errorService;
        private readonly IMapper _mapper;
        public GetAllSellerByPhoneNumber(ISellerRepository sellerRepository, IErrorService errorService, IMapper mapper)
        {
            _errorService = errorService;
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<GetSellerOutputDTO>>> ExecuteAsync(string phone)
        {
            try
            {
                var result = await _sellerRepository.SelectByPhoneNumberAsync(phone);
                if (result.Count == 0)
                {
                    return OperationResult<List<GetSellerOutputDTO>>.FailedResult(Messages.NoSellerFoundWithPhone);
                }
                var sellerDTO = _mapper.Map<List<GetSellerOutputDTO>>(result);
                return OperationResult<List<GetSellerOutputDTO>>.SuccessedResult(sellerDTO);
            }
            catch (Exception ex)
            {
                var errorResult =await _errorService.LogErrorAsync(ex, GetType().Name);
                return OperationResult<List<GetSellerOutputDTO>>.Failed(errorResult.Message!.ErrorMessage());
            }
        }
    }
}
