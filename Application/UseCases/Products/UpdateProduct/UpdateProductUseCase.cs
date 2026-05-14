using AutoMapper;
using FluentValidation;
using FluentValidation.Internal;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateProductInputDTO> _validator;
        public UpdateProductUseCase(
            IProductRepository productRepository,
            IFileStorageService fileStorageService,
            IErrorRepository errorRepository,
            IMapper mapper,
            IValidator<UpdateProductInputDTO> validator)
        {
            _productRepository = productRepository;
            _fileStorageService = fileStorageService;
            _errorRepository = errorRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<OperationResult> ExecuteAsync(UpdateProductInputDTO updateProductInputDTO, Stream stream, CancellationToken token)
        {
            var validationResult = _validator.Validate(updateProductInputDTO);
            if (!validationResult.IsValid)
            {
                return OperationResult.FailedResult(validationResult.Errors.First().ErrorMessage);
            }

            if (!updateProductInputDTO.ImageProduct!.StartsWith(Messages.Url))
            {
                try
                {
                    var urlImage = await _fileStorageService.SaveAsync(stream!, updateProductInputDTO.ImageProduct, token);
                    updateProductInputDTO.ImageProduct = urlImage;
                }
                catch (Exception ex)
                {
                    var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(Messages.SavePhotoLayer));
                    return OperationResult.Failed(Messages.UnsuccessfulSavePhoto);
                }
            }

            try
            {
                var product = _mapper.Map<Product>(updateProductInputDTO);
                await _productRepository.UpdateAsync(product, token);
                return OperationResult.SuccessedResult(Messages.UpdateSuccessful);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
