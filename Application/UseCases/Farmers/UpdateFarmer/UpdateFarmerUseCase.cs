using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.UpdateFarmer
{
    public class UpdateFarmerUseCase : IUpdateFarmerUseCase
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateFarmerInputDTO> _validator;
        private readonly IUserRepository _userRepository;
        private readonly IFarmerRepository _farmerRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateFarmerUseCase(
            IErrorRepository errorRepository,
            IMapper mapper,
            IValidator<UpdateFarmerInputDTO> validator,
            IUserRepository userRepository,
            IFarmerRepository farmerRepository,
            IFileStorageService fileStorageService,
            IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _mapper = mapper;
            _validator = validator;
            _userRepository = userRepository;
            _farmerRepository = farmerRepository;
            _fileStorageService = fileStorageService;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> ExecuteAsync(string username, UpdateFarmerInputDTO updateFarmerInputDTO)
        {
            var validationResult = _validator.Validate(updateFarmerInputDTO);
            if (!validationResult.IsValid)
            {
                return OperationResult.FailedResult(validationResult.Errors.First().ErrorMessage);
            }

            await _unitOfWork.BeginAsync();

            if (updateFarmerInputDTO.NewUsername != updateFarmerInputDTO.CurrentUsername)
            {
                var result = await _userRepository.CheckUserAsync(updateFarmerInputDTO.NewUsername!);
                if (result)
                    return OperationResult.FailedResult(Messages.ExistingUserName);
            }

            try
            {
                if (!updateFarmerInputDTO.ProfileImage!.StartsWith(Messages.Url))
                    updateFarmerInputDTO.ProfileImage = await _fileStorageService.SaveAsync(updateFarmerInputDTO.ProfileImage);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(Messages.UnsuccessfulSavePhoto);
            }

            try
            {
                var user = _mapper.Map<User>(updateFarmerInputDTO);
                await _userRepository.UpdateAsync(user);

                var seller = _mapper.Map<Farmer>(updateFarmerInputDTO);
                await _farmerRepository.UpdateAsync(seller);

                await _unitOfWork.CommitAsync();
                return OperationResult.SuccessedResult(true, Messages.UpdateSuccessful);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
