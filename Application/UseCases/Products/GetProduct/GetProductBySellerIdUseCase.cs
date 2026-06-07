using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.GetProduct
{
    public class GetProductBySellerIdUseCase : IGetProductBySellerIdUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductBySellerIdUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<OperationResult<List<GetProductOutputDTO>>> ExecuteAsync(long sellerId, CancellationToken token)
        {
            var products = await _productRepository.SelectAllBySellerIdAsync(sellerId, token);

            if (!products.Any())
            {
                throw new NotFoundException(Messages.ProductNotFoundBySellerId);
            }

            var productDTO = _mapper.Map<List<GetProductOutputDTO>>(products);
            return OperationResult<List<GetProductOutputDTO>>.Success(productDTO, OperationError.Success);
        }
    }
}
