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

namespace SabzMarket.Application.UseCases.Sellers.CreateSeller
{
    public class CreateSellerUseCase : ICreateSellerUseCase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IValidator<CreateSellerInputDTO> _validator;
        public readonly IMapper _mapper;
        public readonly IFileStorageService _fileStorageService;
        public CreateSellerUseCase(ISellerRepository sellerRepository, IErrorRepository errorRepository, IValidator<CreateSellerInputDTO> validator, IFileStorageService fileStorageService, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _sellerRepository = sellerRepository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }
        public async Task<OperationResult> ExecuteAsync(CreateSellerInputDTO sellerInputDTO, Stream stream, CancellationToken token)
        {
            var validationResult = _validator.Validate(sellerInputDTO);
            if (!validationResult.IsValid)
            {
                return OperationResult.FailedResult(validationResult.Errors.First().ErrorMessage);
            }

            try
            {
                var imageUrl = await _fileStorageService.SaveAsync(stream!, sellerInputDTO.ProfileImage!, token);
                sellerInputDTO.ProfileImage = imageUrl;
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(Messages.SavePhotoLayer));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }

            try
            {
                var seller = _mapper.Map<Seller>(sellerInputDTO);
                await _sellerRepository.InsertAsync(sellerInputDTO.Username!, seller, token);
                return OperationResult.SuccessedResult(Messages.SaveSellerProfileSuccessful);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }

        }
    }
}
