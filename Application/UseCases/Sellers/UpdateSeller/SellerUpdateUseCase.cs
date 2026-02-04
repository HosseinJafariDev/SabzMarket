using Application.Interfaces.Services;
using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repositories.Services;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.UpdateSeller
{
    public class SellerUpdateUseCase : ISellerUpdateUseCase
    {
        public readonly IUserRepository _userRepository;
        public readonly ISellerRepository _sellerRepository;
        public readonly IFileStorageService _fileStorageService;
        public readonly IMapper _mapper;
        private readonly IValidator<SellerUpdateInputDTO> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IErrorService _errorService;
        public SellerUpdateUseCase(
            IUserRepository userRepository,
            ISellerRepository sellerRepository,
            IMapper mapper,
            IValidator<SellerUpdateInputDTO> validator,
            IFileStorageService fileStorageService,
            IUnitOfWork unitOfWork,
            IErrorService errorService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _sellerRepository = sellerRepository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _unitOfWork = unitOfWork;
            _errorService = errorService;
        }
        public async Task<OperationResult> ExecuteAsync(SellerUpdateInputDTO updateSellerInputDTO)
        {
            try
            {
                var validationResult = _validator.Validate(updateSellerInputDTO);
                if (!validationResult.IsValid)
                {
                    return OperationResult.FailedResult(validationResult.Errors.First().ErrorMessage);
                }

                await _unitOfWork.BeginAsync();

                if (updateSellerInputDTO.NewUsername != updateSellerInputDTO.CurrentUsername)
                {
                    var result = await _userRepository.CheckUserAsync(updateSellerInputDTO.NewUsername!);
                    if (result)
                        return OperationResult.FailedResult(Messages.ExistingUserName);
                }

                if (!updateSellerInputDTO.ProfileImage!.StartsWith("http"))
                    updateSellerInputDTO.ProfileImage = await _fileStorageService.SaveAsync(updateSellerInputDTO.ProfileImage);

                var user = _mapper.Map<User>(updateSellerInputDTO);
                await _userRepository.UpdateAsync(user);

                var seller=_mapper.Map<Seller>(updateSellerInputDTO);
                await _sellerRepository.UpdateAsync(seller);
                await _unitOfWork.CommitAsync();
                return OperationResult.SuccessedResult(true,Messages.UpdateSuccessful);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorService.LogErrorAsync(ex, GetType().Name);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }

        }
    }
}
