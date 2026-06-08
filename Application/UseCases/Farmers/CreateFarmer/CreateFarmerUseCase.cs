using AutoMapper;
using FluentValidation;
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

namespace SabzMarket.Application.UseCases.Farmers.CreateFarmer
{
    public class CreateFarmerUseCase : ICreateFarmerUseCase
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IValidator<CreateFarmerInputDTO> _validator;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public CreateFarmerUseCase(
            IFarmerRepository farmerRepository,
            IValidator<CreateFarmerInputDTO> validator,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            _farmerRepository = farmerRepository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        public async Task<OperationResult> ExecuteAsync(string username, CreateFarmerInputDTO createFarmerInputDTO,
            Stream stream, CancellationToken token)
        {
            var farmerValidation = _validator.Validate(createFarmerInputDTO);
            if (!farmerValidation.IsValid)
                throw new BadRequestException(farmerValidation.Errors.First().ErrorMessage);

            var imageUrl = await _fileStorageService.SaveAsync(stream!, createFarmerInputDTO.ProfileImage!, token);
            createFarmerInputDTO.ProfileImage = imageUrl;

            var farmer = _mapper.Map<Farmer>(createFarmerInputDTO);
            await _farmerRepository.InsertAsync(username, farmer, token);

            return OperationResult.Success(OperationError.Success, Messages.SignUpSuccessful);
        }
    }
}