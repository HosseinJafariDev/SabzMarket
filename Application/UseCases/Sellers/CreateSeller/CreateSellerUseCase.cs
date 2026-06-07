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

namespace SabzMarket.Application.UseCases.Sellers.CreateSeller
{
    public class CreateSellerUseCase : ICreateSellerUseCase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IValidator<CreateSellerInputDTO> _validator;
        public readonly IMapper _mapper;
        public readonly IFileStorageService _fileStorageService;
        public CreateSellerUseCase(ISellerRepository sellerRepository, IValidator<CreateSellerInputDTO> validator, IFileStorageService fileStorageService, IMapper mapper)
        {
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
                throw new BadRequestException(validationResult.Errors.First().ErrorMessage);
            }

            var imageUrl = await _fileStorageService.SaveAsync(stream!, sellerInputDTO.ProfileImage!, token);
            sellerInputDTO.ProfileImage = imageUrl;

            var seller = _mapper.Map<Seller>(sellerInputDTO);
            await _sellerRepository.InsertAsync(sellerInputDTO.Username!, seller, token);
            return OperationResult.Success(OperationError.None, Messages.SaveSellerProfileSuccessful);

        }
    }
}
