using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
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

namespace SabzMarket.Application.UseCases.Farmers.UpdateFarmer
{
    public class UpdateFarmerUseCase : IUpdateFarmerUseCase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateFarmerInputDTO> _validator;
        private readonly IUserRepository _userRepository;
        private readonly IFarmerRepository _farmerRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFarmerUseCase(
            IMapper mapper,
            IValidator<UpdateFarmerInputDTO> validator,
            IUserRepository userRepository,
            IFarmerRepository farmerRepository,
            IFileStorageService fileStorageService,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _userRepository = userRepository;
            _farmerRepository = farmerRepository;
            _fileStorageService = fileStorageService;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> ExecuteAsync(UpdateFarmerInputDTO updateFarmerInputDTO, Stream stream,
            CancellationToken token)
        {
            var validationResult = _validator.Validate(updateFarmerInputDTO);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult.Errors.First().ErrorMessage);

            await _unitOfWork.BeginAsync();

            if (updateFarmerInputDTO.NewUsername != updateFarmerInputDTO.CurrentUsername)
            {
                var result = await _userRepository.CheckUserAsync(updateFarmerInputDTO.NewUsername!, token);
                if (result)
                    return OperationResult.Failed(OperationError.Validation, Messages.ExistingUserName);
            }

            if (!updateFarmerInputDTO.ProfileImage!.StartsWith(Messages.Url))
                updateFarmerInputDTO.ProfileImage = await _fileStorageService
                    .SaveAsync(stream!, updateFarmerInputDTO.ProfileImage, token);

            try
            {
                var user = _mapper.Map<User>(updateFarmerInputDTO);
                await _userRepository.UpdateAsync(user, token);

                var farmer = _mapper.Map<Farmer>(updateFarmerInputDTO);
                await _farmerRepository.UpdateAsync(farmer, token);

                await _unitOfWork.CommitAsync();
                return OperationResult.Success(OperationError.None, Messages.UpdateSuccessful);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}