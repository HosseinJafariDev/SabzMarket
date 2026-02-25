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
    public class GetProductByNameUseCase : IGetProductByNameUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        public GetProductByNameUseCase(IProductRepository productRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<GetProductOutputDTO>>> ExecuteAsync(string name)
        {
            try
            {
                var products = await _productRepository
                    .SelectByNameAsync(name);

                if (!products.Any())
                {
                    return OperationResult<List<GetProductOutputDTO>>.FailedResult(Messages.ProductNotFoundByName);
                }

                var productsDTO = _mapper
                    .Map<List<GetProductOutputDTO>>(products);

                return OperationResult<List<GetProductOutputDTO>>
                    .SuccessedResult(productsDTO);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository
                    .LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));

                return OperationResult<List<GetProductOutputDTO>>
                    .Failed(errorResult.ErrorMessage());
            }
        }
    }
}
