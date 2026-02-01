using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Mappers;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application
{
    public class FeaturedSellerSevice : IFeaturedSellerSevice
    {
        private readonly IFeaturedSellerRepository _repository;
        private readonly IErrorService _errorService;
        public FeaturedSellerSevice(IFeaturedSellerRepository repository, IErrorService errorService) 
        {
            _repository = repository;
            _errorService = errorService;
        }
        public async Task<OperationResult<List<SellerFullViewModel>>> GetAllSellerAsync()
        {
            var result = await _repository.SelectAllSellerAsync();
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError=await _errorService.LogErrorAsync(error);
                return OperationResult<List<SellerFullViewModel>>.Failed(resultError.Message!.ErrorMessage());
            }
            List < SellerFullViewModel > seller =result.Data.Select(x=>x.ToSellerFullViewModel()).ToList(); 
            return OperationResult<List<SellerFullViewModel>>.SuccessedResult(seller);
        }
    }
}
