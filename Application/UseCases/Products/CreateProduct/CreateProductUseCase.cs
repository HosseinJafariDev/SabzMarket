using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.CreateProduct
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductInputDTO> _validator;

        public CreateProductUseCase(
            IProductRepository productRepository,
            IFileStorageService fileStorageService,
            IMapper mapper,
            IValidator<CreateProductInputDTO> validator)
        {
            _productRepository = productRepository;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<OperationResult> ExecuteAsync(CreateProductInputDTO createProductInputDTO, Stream stream, CancellationToken token)
        {
            var validationResult = _validator.Validate(createProductInputDTO);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors.First().ErrorMessage);
            }

            var imageUrl = await _fileStorageService.SaveAsync(stream!, createProductInputDTO.ImageProduct!, token);
            createProductInputDTO.ImageProduct = imageUrl;

            var product = _mapper.Map<Product>(createProductInputDTO);
            await _productRepository.InsertAsync(product, token);

            return OperationResult.Success(OperationError.None, Messages.CreateProductSuccessful);
        }
    }
}
