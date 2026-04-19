using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities;
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
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductInputDTO> _validator;

        public CreateProductUseCase(
            IProductRepository productRepository,
            IFileStorageService fileStorageService,
            IErrorRepository errorRepository,
            IMapper mapper,
            IValidator<CreateProductInputDTO> validator)
        {
            _errorRepository = errorRepository;
            _productRepository = productRepository;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<OperationResult> ExecuteAsync(CreateProductInputDTO createProductInputDTO, Stream stream)
        {
            var validationResult = _validator.Validate(createProductInputDTO);
            if (!validationResult.IsValid)
            {
                return OperationResult.FailedResult(validationResult.Errors.First().ErrorMessage);
            }

            try
            {
                var imageUrl = await _fileStorageService.SaveAsync(stream!, createProductInputDTO.ImageProduct!);
                createProductInputDTO.ImageProduct = imageUrl;
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(Messages.SavePhotoLayer));
                return OperationResult.Failed(Messages.UnsuccessfulSavePhoto);
            }

            try
            {
                var product = _mapper.Map<Product>(createProductInputDTO);
                await _productRepository.InsertAsync(product);

                return OperationResult.SuccessedResult(Messages.CreateProductSuccessful);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
