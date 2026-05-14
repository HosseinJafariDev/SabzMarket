using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Categories.GetCategory
{
    public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {
        private readonly IMapper _mapper;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IErrorRepository _errorRepository;
        public GetAllCategoriesUseCase(
            IMapper mapper,
            ICategorieRepository categorieRepository,
            IErrorRepository errorRepository)
        {
            _categorieRepository = categorieRepository;
            _errorRepository = errorRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<GetAllCategoriesOutputDTO>>> ExecuteAsync(CancellationToken token)
        {
            try
            {
                var result = await _categorieRepository.SelectAsync(token);
                var getAllCategoriesOutputDTO = _mapper.Map<List<GetAllCategoriesOutputDTO>>(result);
                return OperationResult<List<GetAllCategoriesOutputDTO>>.SuccessedResult(getAllCategoriesOutputDTO);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<List<GetAllCategoriesOutputDTO>>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
