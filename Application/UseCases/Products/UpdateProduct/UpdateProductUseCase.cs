using AutoMapper;
using FluentValidation;
using FluentValidation.Internal;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateProductInputDTO> _validator;

        public UpdateProductUseCase(
            IProductRepository productRepository,
            IFileStorageService fileStorageService,
            IMapper mapper,
            IValidator<UpdateProductInputDTO> validator)
        {
            _productRepository = productRepository;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<OperationResult> ExecuteAsync(UpdateProductInputDTO updateProductInputDTO, Stream stream,
            CancellationToken token)
        {
            var validationResult = _validator.Validate(updateProductInputDTO);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult.Errors.First().ErrorMessage);

            if (!updateProductInputDTO.ImageProduct!.StartsWith(Messages.Url))
            {
                var urlImage =
                    await _fileStorageService.SaveAsync(stream!, updateProductInputDTO.ImageProduct, token);
                updateProductInputDTO.ImageProduct = urlImage;
            }

            var product = _mapper.Map<Product>(updateProductInputDTO);
            await _productRepository.UpdateAsync(product, token);

            return OperationResult.Success(OperationError.None, Messages.UpdateSuccessful);
        }
    }
}