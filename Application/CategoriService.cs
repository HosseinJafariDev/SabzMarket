using SabzMarket.Share.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Share.Models;
using SabzMarket.Share.ErrorHandling;
using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Repository;
namespace SabzMarket.Application
{
    public class CategoriService : ICategoriService
    {
        public readonly ICategorieRepository _categorieRepository;
        public readonly IErrorService _errorService;
        public CategoriService(ICategorieRepository categorieRepository, IErrorService errorService) 
        {
            _categorieRepository = categorieRepository;
            _errorService = errorService;
        }
        public async Task<OperationResult<List<CategorieDTO>>> GetAllCategoriesAsync()
        {
            var result = await _categorieRepository.SelectAsync();
            if(!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult<List<CategorieDTO>>.Failed(result.Message!.ErrorMessage());
            }
            return result;
        }
    }
}
