using Application.Interfaces.Services;
using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repositories.Services;
using SabzMarket.Application.Interfaces.Repository;
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
        private readonly IErrorService _errorService;
        private readonly IValidator<CreateSellerInputDTO> _validator;
        public readonly IMapper _mapper;
        public readonly IFileStorageService _fileStorageService;
        public CreateSellerUseCase(ISellerRepository sellerRepository, IErrorService errorService, IValidator<CreateSellerInputDTO> validator, IFileStorageService fileStorageService, IMapper mapper)
        {
            _errorService = errorService;
            _sellerRepository = sellerRepository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }
        public async Task<OperationResult> ExecuteAsync(CreateSellerInputDTO sellerInputDTO)
        {
            try
            {
                var validationResult = _validator.Validate(sellerInputDTO);
                if (!validationResult.IsValid)
                {
                    return OperationResult.FailedResult(validationResult.Errors.First().ErrorMessage);
                }
                var imageUrl = await _fileStorageService.SaveAsync(sellerInputDTO.ProfileImage!);
                sellerInputDTO.ProfileImage = imageUrl;
                var seller = _mapper.Map<Seller>(sellerInputDTO);
                await _sellerRepository.InsertAsync(sellerInputDTO.Username!, seller);
                return OperationResult.SuccessedResult(true, Messages.SaveSellerProfileSuccessful);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorService.LogErrorAsync(ex, GetType().Name);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }

        }
    }
}
