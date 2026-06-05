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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.UpdateSeller
{
    public class SellerUpdateUseCase : ISellerUpdateUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private readonly IValidator<SellerUpdateInputDTO> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IErrorRepository _errorRepository;
        public SellerUpdateUseCase(
            IUserRepository userRepository,
            ISellerRepository sellerRepository,
            IMapper mapper,
            IValidator<SellerUpdateInputDTO> validator,
            IFileStorageService fileStorageService,
            IUnitOfWork unitOfWork,
            IErrorRepository errorRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _sellerRepository = sellerRepository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _unitOfWork = unitOfWork;
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult> ExecuteAsync(SellerUpdateInputDTO updateSellerInputDTO, Stream stream, CancellationToken token)
        {
            var validationResult = _validator.Validate(updateSellerInputDTO);
            if (!validationResult.IsValid)
            {
                return OperationResult.Failed(OperationError.Validation, validationResult.Errors.First().ErrorMessage);
            }

            await _unitOfWork.BeginAsync();

            if (updateSellerInputDTO.NewUsername != updateSellerInputDTO.CurrentUsername)
            {
                var result = await _userRepository.CheckUserAsync(updateSellerInputDTO.NewUsername!, token);
                if (result)
                    return OperationResult.Failed(OperationError.Conflict, Messages.ExistingUserName);
            }

            try
            {
                if (!updateSellerInputDTO.ProfileImage!.StartsWith(Messages.Url))
                    updateSellerInputDTO.ProfileImage = await _fileStorageService
                        .SaveAsync(stream!, updateSellerInputDTO.ProfileImage, token);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(Messages.SavePhotoLayer));
                return OperationResult.Failed(OperationError.ServerError, Messages.UnsuccessfulSavePhoto);
            }

            try
            {
                var user = _mapper.Map<User>(updateSellerInputDTO);
                await _userRepository.UpdateAsync(user, token);

                var seller = _mapper.Map<Seller>(updateSellerInputDTO);
                await _sellerRepository.UpdateAsync(seller, token);
                await _unitOfWork.CommitAsync();
                return OperationResult.Success(OperationError.None, Messages.UpdateSuccessful);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(OperationError.ServerError, errorResult.ErrorMessage());
            }

        }
    }
}
