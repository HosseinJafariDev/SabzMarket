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
        public async Task<OperationResult<GetSellerOutputDTO>> ExecuteAsync(string username)
        {
            try
            {
                var seller = await _sellerRepository.SelectByUsernameAsync(username);
                if (seller == null)
                {
                    return OperationResult<GetSellerOutputDTO>.FailedResult(Messages.NoSellerFoundWhithUsename);
                }
                var sellerDTO = _mapper.Map<GetSellerOutputDTO>(seller);
                return OperationResult<GetSellerOutputDTO>.SuccessedResult(sellerDTO);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<GetSellerOutputDTO>.Failed(errorResult.ErrorMessage());
            }

        }
    }
}

