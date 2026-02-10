using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.GetProduct
{
    public class GetProductBySellerIdUseCase : IGetProductBySellerIdUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        public GetProductBySellerIdUseCase(IProductRepository productRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<OperationResult<List<GetProductOutputDTO>>> ExecuteAsync(long sellerId)
        {
            try
            {
                var products = await _productRepository.SelectAllBySellerIdAsync(sellerId);

                if (products.Any())
                {
                    return OperationResult<List<GetProductOutputDTO>>.FailedResult(Messages.ProductNotFoundBySellerId);
                }

                var productDTO = _mapper.Map<List<GetProductOutputDTO>>(products);
                return OperationResult<List<GetProductOutputDTO>>.SuccessedResult(productDTO);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex, GetType().Name);
                return OperationResult<List<GetProductOutputDTO>>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
