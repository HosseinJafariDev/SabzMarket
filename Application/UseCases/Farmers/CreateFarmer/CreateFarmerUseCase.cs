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

namespace SabzMarket.Application.UseCases.Farmers.CreateFarmer
{
    public class CreateFarmerUseCase : ICreateFarmerUseCase
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IFarmerRepository _farmerRepository;
        private readonly IValidator<CreateFarmerInputDTO> _validator;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        public CreateFarmerUseCase(
            IErrorRepository errorRepository,
            IFarmerRepository farmerRepository,
            IValidator<CreateFarmerInputDTO> validator,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            _errorRepository = errorRepository;
            _farmerRepository = farmerRepository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }
        public async Task<OperationResult> ExecuteAsync(string username, CreateFarmerInputDTO createFarmerInputDTO)
        {
            try
            {
                var farmerValidation = _validator.Validate(createFarmerInputDTO);
                if (!farmerValidation.IsValid)
                {
                    return OperationResult.FailedResult(farmerValidation.Errors.First().ErrorMessage);
                }

                var imageURL = await _fileStorageService.SaveAsync(createFarmerInputDTO.ProfileImage!);
                createFarmerInputDTO.ProfileImage = imageURL;

                var farmer = _mapper.Map<Farmer>(createFarmerInputDTO);
                await _farmerRepository.InsertAsync(username, farmer);
                return OperationResult.SuccessedResult(true, Messages.SignUpSuccessful);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
