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

namespace SabzMarket.Application.UseCases.Products.GetProduct
{
    public class GetProductByNameUseCase : IGetProductByNameUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByNameUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<GetProductOutputDTO>>> ExecuteAsync(string name, CancellationToken token)
        {
            var products = await _productRepository
                .SelectByNameAsync(name, token);

            if (!products.Any())
            {
                throw new NotFoundException(Messages.ProductNotFoundByName);
            }

            var productsDTO = _mapper
                .Map<List<GetProductOutputDTO>>(products);

            return OperationResult<List<GetProductOutputDTO>>
                .Success(productsDTO, OperationError.Success);
        }
    }
}
