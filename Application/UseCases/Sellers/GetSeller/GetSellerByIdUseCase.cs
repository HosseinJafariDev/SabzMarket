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
        public async Task<OperationResult<GetSellerOutputDTO>> ExecuteAsync(long id)
        {
            try
            {
                var result = await _sellerRepository.SelectByIdAsync(id);
                if (result == null)
                {
                    return OperationResult<GetSellerOutputDTO>.Failed(Messages.NoSellerFoundWithId);
                }
                var sellerDTO = _mapper.Map<GetSellerOutputDTO>(result);
                return OperationResult<GetSellerOutputDTO>.SuccessedResult(sellerDTO);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex, GetType().Name);
                return OperationResult<GetSellerOutputDTO>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
